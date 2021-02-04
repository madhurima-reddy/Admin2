using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Admin.Models;

namespace Admin.Controllers
{
    public class Report_cardController : ApiController

    {
        private OnlineExam1Entities db = new OnlineExam1Entities();

        //public IQueryable<Report_card> GetReport_card()
        //{
        //    return db.Report_card;
        //}

        // GET: api/Report_card/5
        [HttpGet]
        public IHttpActionResult GetReport_card(int id)
        {
            var report_card = db.Report_card.Where(x => x.User_id == id);

            return Ok(report_card);
        }


        [HttpPost]
        public IHttpActionResult PostReport(Report_card report)
        {
            Report_card p = db.Report_card.Find(report.ReportCard_id);



            if (p != null)
            {
                return BadRequest();
            }
            else
            {
                db.Report_card.Add(report);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
