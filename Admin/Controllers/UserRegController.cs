using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Admin.Models;
using System.Web.Http;

namespace Admin.Controllers
{
    public class UserRegController : ApiController
    {
         OnlineExam1Entities entities= new OnlineExam1Entities();

        public IHttpActionResult GetRegistration()
        {
            return Ok(entities.User_Module);
        }

        public IHttpActionResult PostRegister(User_Module r)
        {
            User_Module p = entities.User_Module.Find(r.User_id);

            if (p != null)
            {
                return BadRequest();
            }
            else
            {
                entities.User_Module.Add(r);
                entities.SaveChanges();
                return Ok();
            }
        }


    }
}
