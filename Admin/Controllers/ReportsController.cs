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


        public IHttpActionResult GetReports(string state, string city, string Course_name, string marks)
        {
            return Ok(entities.adminreport3(state,city,Course_name,marks));

        }
           




    }
}
