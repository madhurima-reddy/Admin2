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
    public class User_Module1Controller : ApiController
    {
        private OnlineExam1Entities db = new OnlineExam1Entities();

        // GET: api/User_Module1
        public IQueryable<User_Module> GetUser_Module()
        {
            return db.User_Module;
        }

        // GET: api/User_Module1/5
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

       
        // POST: api/User_Module1
        [ResponseType(typeof(User_Module))]
        public IHttpActionResult PostUser_Module(User_Module user)
        {
            User_Module User = db.User_Module.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (User == null)
            {
                return Ok(User);

            }
            return Ok(User);
        }

        
        
    }
}