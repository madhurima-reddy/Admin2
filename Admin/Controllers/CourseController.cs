using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Admin.Models;

namespace Admin.Controllers
{
    public class CourseController : ApiController
    {
        private OnlineExam1Entities db = new OnlineExam1Entities();
        public IHttpActionResult GetAll()
        {
            return Ok(db.Courses);
        }
        public IHttpActionResult GetByID(int Course_id)
        {
            return Ok(db.Courses.Where(x => x.Course_id == Course_id).FirstOrDefault());
        }



    }
}

