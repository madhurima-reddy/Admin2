using Admin.Models;
using System.Linq;
using System.Web.Http;

namespace Admin.Controllers
{
    public class coursesController : ApiController
    {
        private OnlineExam1Entities db = new OnlineExam1Entities();
        public IHttpActionResult GetCourses()
        {
            return Ok(db.Courses);
        }

        public IHttpActionResult GetByID(int Course_id, int Level_id)
        {
            return Ok(db.Questions.Where(x => x.Course_id == Course_id && x.Level_id == Level_id));
        }
    }
}
