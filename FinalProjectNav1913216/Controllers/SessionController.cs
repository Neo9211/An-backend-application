using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectNav1913216.Models;
using FinalProjectNav1913216.Data;

namespace FinalProjectNav1913216.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Session>> Get()
        {
            var sessions = _context.Sessions.ToList();

            if (sessions is null)
            {
                return NotFound();
            }
            
            return sessions;
        }
        
        [HttpPost]
        public ActionResult Post(Session session)
        {
            _context.Add(session);
            var user = _context.Users.Find(session.Email);
            if (user == null)
            {
                return NotFound();
            }

            if (user.Password != session.Password)
            {
                return Unauthorized();
            }

            session.Token = Guid.NewGuid().ToString();
            _context.Sessions.Add(session);
            _context.SaveChanges();

            return Ok(session);
        }

        [HttpDelete]
        public ActionResult Delete(Session session)
        {
            var sessionToDelete = _context.Sessions.Find(session.Token);
            if (sessionToDelete == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(sessionToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
