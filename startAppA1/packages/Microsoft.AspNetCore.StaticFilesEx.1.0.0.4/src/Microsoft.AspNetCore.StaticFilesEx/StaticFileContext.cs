// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.StaticFilesEx.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.StaticFilesEx
{
	public class StaticFileContext
    {
		public HttpContext HttpContext { get; }
        protected readonly StaticFileOptions Options;
        protected readonly PathString MatchUrl;
		protected readonly HttpRequest Request;
		protected readonly HttpResponse Response;
        protected readonly ILogger Logger;
        protected readonly IFileProvider FileProvider;
        protected readonly IContentTypeProvider ContentTypeProvider;
        protected string Method { get; set; }
		protected bool IsGet { get; set; }
		protected bool IsHead { get; set; }
        protected PathString SubPathString { get; set; }
		protected string ContentType { get; set; }
		protected IFileInfo FileInfo { get; set; }
		protected long Length { get; set; }
		protected DateTimeOffset LastModified { get; set; }
		protected EntityTagHeaderValue Etag { get; set; }

		protected RequestHeaders RequestHeaders { get; set; }
		protected ResponseHeaders ResponseHeaders { get; set; }

		private PreconditionState _ifMatchState;
        private PreconditionState _ifNoneMatchState;
        private PreconditionState _ifModifiedSinceState;
        private PreconditionState _ifUnmodifiedSinceState;

		protected IList<RangeItemHeaderValue> Ranges;

        public StaticFileContext(HttpContext httpContext, StaticFileOptions options, PathString matchUrl, ILogger logger, IFileProvider fileProvider, IContentTypeProvider contentTypeProvider)
        {
            HttpContext = httpContext;
            Options = options;
            MatchUrl = matchUrl;
            Request = httpContext.Request;
            Response = httpContext.Response;
            Logger = logger;
            RequestHeaders = Request.GetTypedHeaders();
            ResponseHeaders = Response.GetTypedHeaders();
            FileProvider = fileProvider;
            ContentTypeProvider = contentTypeProvider;

            Method = null;
            IsGet = false;
            IsHead = false;
            SubPathString = PathString.Empty;
            ContentType = null;
            FileInfo = null;
            Length = 0;
            LastModified = new DateTimeOffset();
            Etag = null;
            _ifMatchState = PreconditionState.Unspecified;
            _ifNoneMatchState = PreconditionState.Unspecified;
            _ifModifiedSinceState = PreconditionState.Unspecified;
            _ifUnmodifiedSinceState = PreconditionState.Unspecified;
            Ranges = null;
        }

        internal enum PreconditionState
        {
            Unspecified,
            NotModified,
            ShouldProcess,
            PreconditionFailed,
        }

        public virtual bool IsHeadMethod => IsHead;

	    public virtual bool IsRangeRequest => Ranges != null;

	    public string SubPath => SubPathString.Value;

	    public virtual string PhysicalPath => FileInfo?.PhysicalPath;

	    public virtual bool ValidateMethod()
        {
            Method = Request.Method;
            IsGet = Helpers.IsGetMethod(Method);
            IsHead = Helpers.IsHeadMethod(Method);
            return IsGet || IsHead;
        }

        // Check if the URL matches any expected paths
        public virtual bool ValidatePath()
        {
	        PathString subPathString;
            var rtn = Helpers.TryMatchPath(HttpContext, MatchUrl, forDirectory: false, subpath: out subPathString);
	        SubPathString = subPathString;
	        return rtn;
        }

        public virtual bool LookupContentType()
        {
	        string contentType;
            if (ContentTypeProvider.TryGetContentType(SubPathString.Value, out contentType))
            {
	            ContentType = contentType;
                return true;
            }

	        if (!Options.ServeUnknownFileTypes)
	        {
		        return false;
	        }
	        ContentType = Options.DefaultContentType;
	        return true;
        }

        public virtual bool LookupFileInfo()
        {
            FileInfo = FileProvider.GetFileInfo(LookupFilePath());
            if (FileInfo.Exists)
            {
                Length = FileInfo.Length;

                var last = FileInfo.LastModified;
                // Truncate to the second.
                LastModified = new DateTimeOffset(last.Year, last.Month, last.Day, last.Hour, last.Minute, last.Second, last.Offset).ToUniversalTime();

                var etagHash = LastModified.ToFileTime() ^ Length;
                Etag = new EntityTagHeaderValue($"{'\"'}{Convert.ToString(etagHash, 16)}{'\"'}");
            }
            return FileInfo.Exists;
        }

	    protected virtual string LookupFilePath()
	    {
		    return SubPathString.Value;
	    }

	    public virtual void ComprehendRequestHeaders()
        {
            ComputeIfMatch();

            ComputeIfModifiedSince();

            ComputeRange();
        }

        protected virtual void ComputeIfMatch()
        {
            // 14.24 If-Match
            var ifMatch = RequestHeaders.IfMatch;
            if (ifMatch != null && ifMatch.Any())
            {
                _ifMatchState = PreconditionState.PreconditionFailed;
                foreach (var etag in ifMatch)
                {
                    if (etag.Equals(EntityTagHeaderValue.Any) || etag.Equals(Etag))
                    {
                        _ifMatchState = PreconditionState.ShouldProcess;
                        break;
                    }
                }
            }

            // 14.26 If-None-Match
            var ifNoneMatch = RequestHeaders.IfNoneMatch;
            if (ifNoneMatch != null && ifNoneMatch.Any())
            {
                _ifNoneMatchState = PreconditionState.ShouldProcess;
                foreach (var etag in ifNoneMatch)
                {
                    if (etag.Equals(EntityTagHeaderValue.Any) || etag.Equals(Etag))
                    {
                        _ifNoneMatchState = PreconditionState.NotModified;
                        break;
                    }
                }
            }
        }

		protected virtual void ComputeIfModifiedSince()
        {
            var now = DateTimeOffset.UtcNow;

            // 14.25 If-Modified-Since
            var ifModifiedSince = RequestHeaders.IfModifiedSince;
            if (ifModifiedSince.HasValue && ifModifiedSince <= now)
            {
                bool modified = ifModifiedSince < LastModified;
                _ifModifiedSinceState = modified ? PreconditionState.ShouldProcess : PreconditionState.NotModified;
            }

            // 14.28 If-Unmodified-Since
            var ifUnmodifiedSince = RequestHeaders.IfUnmodifiedSince;
            if (ifUnmodifiedSince.HasValue && ifModifiedSince <= now)
            {
                bool unmodified = ifUnmodifiedSince >= LastModified;
                _ifUnmodifiedSinceState = unmodified ? PreconditionState.ShouldProcess : PreconditionState.PreconditionFailed;
            }
        }

		protected virtual void ComputeRange()
        {
            // 14.35 Range
            // http://tools.ietf.org/html/draft-ietf-httpbis-p5-range-24

            // A server MUST ignore a Range header field received with a request method other
            // than GET.
            if (!IsGet)
            {
                return;
            }

            var rawRangeHeader = Request.Headers[HeaderNames.Range];
            if (StringValues.IsNullOrEmpty(rawRangeHeader))
            {
                return;
            }

            // Perf: Check for a single entry before parsing it
            if (rawRangeHeader.Count > 1 || rawRangeHeader[0].IndexOf(',') >= 0)
            {
                // The spec allows for multiple ranges but we choose not to support them because the client may request
                // very strange ranges (e.g. each byte separately, overlapping ranges, etc.) that could negatively
                // impact the server. Ignore the header and serve the response normally.
                Logger.LogMultipleFileRanges(rawRangeHeader.ToString());
                return;
            }

            var rangeHeader = RequestHeaders.Range;
            if (rangeHeader == null)
            {
                // Invalid
                return;
            }

            // Already verified above
            Debug.Assert(rangeHeader.Ranges.Count == 1);

            // 14.27 If-Range
            var ifRangeHeader = RequestHeaders.IfRange;
            if (ifRangeHeader != null)
            {
                // If the validator given in the If-Range header field matches the
                // current validator for the selected representation of the target
                // resource, then the server SHOULD process the Range header field as
                // requested.  If the validator does not match, the server MUST ignore
                // the Range header field.
                bool ignoreRangeHeader = false;
                if (ifRangeHeader.LastModified.HasValue)
                {
                    if (LastModified > ifRangeHeader.LastModified)
                    {
                        ignoreRangeHeader = true;
                    }
                }
                else if (ifRangeHeader.EntityTag != null && !Etag.Equals(ifRangeHeader.EntityTag))
                {
                    ignoreRangeHeader = true;
                }
                if (ignoreRangeHeader)
                {
                    return;
                }
            }

            Ranges = RangeHelpers.NormalizeRanges(rangeHeader.Ranges, Length);
        }

		protected virtual void ApplyResponseHeaders(int statusCode)
        {
            Response.StatusCode = statusCode;
            if (statusCode < 400)
            {
                // these headers are returned for 200, 206, and 304
                // they are not returned for 412 and 416
                if (!string.IsNullOrEmpty(ContentType))
                {
                    Response.ContentType = ContentType;
                }
                ResponseHeaders.LastModified = LastModified;
                ResponseHeaders.ETag = Etag;
                ResponseHeaders.Headers[HeaderNames.AcceptRanges] = "bytes";
            }
            if (statusCode == Constants.Status200Ok)
            {
                // this header is only returned here for 200
                // it already set to the returned range for 206
                // it is not returned for 304, 412, and 416
                Response.ContentLength = Length;
            }
            Options.OnPrepareResponse(new StaticFileResponseContext()
            {
                Context = HttpContext,
                File = FileInfo,
            });
        }

        internal PreconditionState GetPreconditionState()
        {
            return GetMaxPreconditionState(_ifMatchState, _ifNoneMatchState,
                _ifModifiedSinceState, _ifUnmodifiedSinceState);
        }

        private static PreconditionState GetMaxPreconditionState(params PreconditionState[] states)
        {
            PreconditionState max = PreconditionState.Unspecified;
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] > max)
                {
                    max = states[i];
                }
            }
            return max;
        }

        public virtual Task SendStatusAsync(int statusCode)
        {
            ApplyResponseHeaders(statusCode);

            Logger.LogHandled(statusCode, SubPath);
            return Constants.CompletedTask;
        }

        public virtual void SendOk()
        {
	        ApplyResponseHeaders(Constants.Status200Ok);
        }

	    public virtual async Task SendContentsAsync()
	    {
		    await HttpContext.SendContentsAsync(FileInfo.PhysicalPath);
	    }

	    // When there is only a single range the bytes are sent directly in the body.
        public virtual async Task SendRangeAsync()
        {
            bool rangeNotSatisfiable = false;
            if (Ranges.Count == 0)
            {
                rangeNotSatisfiable = true;
            }

            if (rangeNotSatisfiable)
            {
                // 14.16 Content-Range - A server sending a response with status code 416 (Requested range not satisfiable)
                // SHOULD include a Content-Range field with a byte-range-resp-spec of "*". The instance-length specifies
                // the current length of the selected resource.  e.g. */length
                ResponseHeaders.ContentRange = new ContentRangeHeaderValue(Length);
                ApplyResponseHeaders(Constants.Status416RangeNotSatisfiable);

                Logger.LogRangeNotSatisfiable(SubPath);
                return;
            }

            // Multi-range is not supported.
            Debug.Assert(Ranges.Count == 1);

            long start, length;
            ResponseHeaders.ContentRange = ComputeContentRange(Ranges[0], out start, out length);
            Response.ContentLength = length;
            ApplyResponseHeaders(Constants.Status206PartialContent);

            string physicalPath = FileInfo.PhysicalPath;
            var sendFile = HttpContext.Features.Get<IHttpSendFileFeature>();
            if (sendFile != null && !string.IsNullOrEmpty(physicalPath))
            {
                Logger.LogSendingFileRange(Response.Headers[HeaderNames.ContentRange], physicalPath);
                await sendFile.SendFileAsync(physicalPath, start, length, HttpContext.RequestAborted);
                return;
            }

            Stream readStream = FileInfo.CreateReadStream();
            try
            {
                readStream.Seek(start, SeekOrigin.Begin); // TODO: What if !CanSeek?
                Logger.LogCopyingFileRange(Response.Headers[HeaderNames.ContentRange], SubPath);
                await StreamCopyOperation.CopyToAsync(readStream, Response.Body, length, HttpContext.RequestAborted);
            }
            finally
            {
                readStream.Dispose();
            }
        }

        // Note: This assumes ranges have been normalized to absolute byte offsets.
        private ContentRangeHeaderValue ComputeContentRange(RangeItemHeaderValue range, out long start, out long length)
        {
            start = range.From.Value;
            long end = range.To.Value;
            length = end - start + 1;
            return new ContentRangeHeaderValue(start, end, Length);
        }
    }
}
