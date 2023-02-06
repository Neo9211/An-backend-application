using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FinalProjectNav1913216.Models;
using FinalProjectNav1913216.Data;

namespace FinalProjectNav1913216.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var token = Request.Headers["Authorization"];
            var session = _context.Sessions.Find(token);
            if (session == null)
            {
                return Unauthorized();
            }

            var tasks = _context.Tasks.Where(t => t.Email == session.Email);
            return Ok(tasks);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Task task)
        {
            var token = Request.Headers["Authorization"];
            var session = _context.Sessions.Find(token);
            if (session == null)
            {
                return Unauthorized();
            }

            task.Email = session.Email;
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpPut]
        public ActionResult Put(Task task)
        {
            var token = Request.Headers["Authorization"];
            var session = _context.Sessions.Find(token);
            if (session == null)
            {
                return Unauthorized();
            }

            var taskToUpdate = _context.Tasks.Find(task.Id);
            if (taskToUpdate == null)
            {
                return NotFound();
            }

            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.DueDate = task.DueDate;
            taskToUpdate.Completed = task.Completed;
            _context.SaveChanges();

            return Ok(taskToUpdate);
        }

        [HttpDelete]
        public ActionResult Delete(Task task)
        {
            var token = Request.Headers["Authorization"];
            var session = _context.Sessions.Find(token);
            if (session == null)
            {
                return Unauthorized();
            }

            var taskToDelete = _context.Tasks.Find(task.Id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
