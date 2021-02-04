using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Admin.Models;

namespace Admin.Controllers
{
    public class QuestionController : ApiController
    {
        private OnlineExam1Entities db = new OnlineExam1Entities();
        public IHttpActionResult GetAll()
        {
            return Ok(db.Questions);
        }
        public IHttpActionResult GetByID(int Course_id, int Level_id)
        {
            return Ok(db.Questions.Where(x => x.Course_id == Course_id && x.Level_id == Level_id));
        }

        public IHttpActionResult GetQuestion(int courseid, int levelid)
        {
            var questions = db.Questions.Where(question => question.Course_id == courseid && question.Level_id == levelid);



            return Ok(questions);
        }


    }
}
