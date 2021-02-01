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
    public class User_ModuleController : ApiController
    {
        private OnlineExam1Entities db = new OnlineExam1Entities();

        // GET: api/User_Module
        public IQueryable<User_Module> GetUser_Module()
        {
            return db.User_Module;
        }

        // GET: api/User_Module/5
        [ResponseType(typeof(User_Module))]
        public IHttpActionResult GetUser_Module(int id)
        {
            User_Module user_Module = db.User_Module.Find(id);
            if (user_Module == null)
            {
                return NotFound();
            }

            return Ok(user_Module);
        }

        // PUT: api/User_Module/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_Module(int id, User_Module user_Module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Module.User_id)
            {
                return BadRequest();
            }

            db.Entry(user_Module).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_ModuleExists(id))
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

        // POST: api/User_Module
        [ResponseType(typeof(User_Module))]
        public IHttpActionResult PostUser_Module(User_Module user_Module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Module.Add(user_Module);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (User_ModuleExists(user_Module.User_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_Module.User_id }, user_Module);
        }

        // DELETE: api/User_Module/5
        [ResponseType(typeof(User_Module))]
        public IHttpActionResult DeleteUser_Module(int id)
        {
            User_Module user_Module = db.User_Module.Find(id);
            if (user_Module == null)
            {
                return NotFound();
            }

            db.User_Module.Remove(user_Module);
            db.SaveChanges();

            return Ok(user_Module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_ModuleExists(int id)
        {
            return db.User_Module.Count(e => e.User_id == id) > 0;
        }
    }
}