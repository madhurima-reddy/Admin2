using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Admin.Models;

namespace Admin.Controllers
{
    public class Admin_ModuleController : ApiController
    {
        private OnlineExam1Entities db = new OnlineExam1Entities();

        // GET: api/Admin_Module
        public IQueryable<Admin_Module> GetAdmin_Module()
        {
            return db.Admin_Module;
        }

        // GET: api/Admin_Module/5
        [ResponseType(typeof(Admin_Module))]
        public IHttpActionResult GetAdmin_Module(int id)
        {
            Admin_Module admin_Module = db.Admin_Module.Find(id);
            if (admin_Module == null)
            {
                return NotFound();
            }

            return Ok(admin_Module);
        }

        // PUT: api/Admin_Module/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdmin_Module(int id, Admin_Module admin_Module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin_Module.Admin_id)
            {
                return BadRequest();
            }

            db.Entry(admin_Module).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Admin_ModuleExists(id))
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

        // POST: api/Admin_Module
        [ResponseType(typeof(Admin_Module))]
        public IHttpActionResult PostAdmin_Module(Admin_Module admin)
        {
            Admin_Module temp = db.Admin_Module.Where(x => x.Email_id == admin.Email_id && x.Password == admin.Password).FirstOrDefault();
            if (temp == null)
            {
                return Ok(0);

            }
            return Ok(1);
        }

        // DELETE: api/Admin_Module/5
        [ResponseType(typeof(Admin_Module))]
        public IHttpActionResult DeleteAdmin_Module(int id)
        {
            Admin_Module admin_Module = db.Admin_Module.Find(id);
            if (admin_Module == null)
            {
                return NotFound();
            }

            db.Admin_Module.Remove(admin_Module);
            db.SaveChanges();

            return Ok(admin_Module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Admin_ModuleExists(int id)
        {
            return db.Admin_Module.Count(e => e.Admin_id == id) > 0;
        }
    }
}