using System.Linq;
using System.Web.Http;
using Task.Models;
using TaskEntity = Task.Models.Task;

namespace Task.Controllers
{
    [RoutePrefix("api/Task")]
    public class TaskController : ApiController
    {
        TODODBEntities db = new TODODBEntities();

        // GET: api/Task
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTasks()
        {
            return Ok(db.Tasks.ToList());
        }

        // GET: api/Task/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTask(int id)
        {
            var task = db.Tasks.Find(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/Task
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddTask([FromBody] TaskEntity task)
        {
            if (task == null)
                return BadRequest("Task data is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Tasks.Add(task);
            db.SaveChanges();

            return Ok("Task Added Successfully");
        }

        // PUT: api/Task/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateTask(int id, [FromBody] TaskEntity task)
        {
            if (task == null)
                return BadRequest("Task data is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTask = db.Tasks.Find(id);

            if (existingTask == null)
                return NotFound();

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.DueDate = task.DueDate;

            db.SaveChanges();

            return Ok("Task Updated Successfully");
        }

        // DELETE: api/Task/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTask(int id)
        {
            var task = db.Tasks.Find(id);

            if (task == null)
                return NotFound();

            db.Tasks.Remove(task);
            db.SaveChanges();

            return Ok("Task Deleted Successfully");
        }
    }
}