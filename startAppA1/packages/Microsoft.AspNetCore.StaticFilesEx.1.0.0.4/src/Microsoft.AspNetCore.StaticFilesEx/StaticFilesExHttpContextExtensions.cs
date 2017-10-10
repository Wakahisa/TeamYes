using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;

namespace Microsoft.AspNetCore.StaticFilesEx
{
	public static class StaticFilesExHttpContextExtensions
	{
		public static async Task SendContentsAsync(this HttpContext httpContext, string physicalPath)
		{
			var fileInfo = new FileInfo(physicalPath);
			var sendFile = httpContext.Features.Get<IHttpSendFileFeature>();
			if (sendFile != null && !string.IsNullOrEmpty(physicalPath))
			{
				await sendFile.SendFileAsync(physicalPath, 0, fileInfo.Length, httpContext.RequestAborted);
				return;
			}

			var readStream = fileInfo.OpenRead();
			try
			{
				await StreamCopyOperation.CopyToAsync(readStream, httpContext.Response.Body, fileInfo.Length, httpContext.RequestAborted);
			}
			finally
			{
				readStream.Dispose();
			}
		}
	}
}