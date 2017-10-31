using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using startAppA1.Models;
using startAppA1.Models.Admin;

namespace startAppA1.Controllers.Admin
{
    public class AdminMainController : ApiController
    {
        private Context db = new Context();

        // GET: api/AdminMain
        public IQueryable<AdminTableModel> GetAdminTableModels()
        {
            return db.AdminTableModels;
        }

        // GET: api/AdminMain/5
        [ResponseType(typeof(AdminTableModel))]
        public IHttpActionResult GetAdminTableModel(int id)
        {
            AdminTableModel adminTableModel = db.AdminTableModels.Find(id);
            if (adminTableModel == null)
            {
                return NotFound();
            }

            return Ok(adminTableModel);
        }

        // PUT: api/AdminMain/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdminTableModel(int id, AdminTableModel adminTableModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminTableModel.TableID)
            {
                return BadRequest();
            }

            db.Entry(adminTableModel).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminTableModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AdminMain
        [ResponseType(typeof(AdminTableModel))]
        public IHttpActionResult PostAdminTableModel(AdminTableModel adminTableModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdminTableModels.Add(adminTableModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adminTableModel.TableID }, adminTableModel);
        }

        // DELETE: api/AdminMain/5
        [ResponseType(typeof(AdminTableModel))]
        public IHttpActionResult DeleteAdminTableModel(int id)
        {
            AdminTableModel adminTableModel = db.AdminTableModels.Find(id);
            if (adminTableModel == null)
            {
                return NotFound();
            }

            db.AdminTableModels.Remove(adminTableModel);
            db.SaveChanges();

            return Ok(adminTableModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminTableModelExists(int id)
        {
            return db.AdminTableModels.Count(e => e.TableID == id) > 0;
        }
    }
}