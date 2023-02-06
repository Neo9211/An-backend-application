using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FinalProjectNav1913216.Models;
using FinalProjectNav1913216.Data;

namespace FinalProjectNav1913216.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post( User user)
        {
            var userToCreate = _context.Find(user.Email);
            if (userToCreate != null)
            {
                return Conflict();
            }

            _context.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}