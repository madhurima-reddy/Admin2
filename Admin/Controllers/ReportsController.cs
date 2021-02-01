using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Admin.Models;


namespace Admin.Controllers
{
    public class ReportsController : ApiController
    {
        OnlineExam1Entities entities = new OnlineExam1Entities();



        public IHttpActionResult GetReports()
        {
            return Ok(entities.Report_card);
        }


        public IHttpActionResult GetReports(int Course_id, string state, string city, int marks)
        {
            var s=entities.Report_card.Where(x => x.Course_id == Course_id && x.User_Module.State == state && x.User_Module.City == city && x.Level_1_Marks > marks).FirstOrDefault();
            return Ok(s);

        }
    }
}
