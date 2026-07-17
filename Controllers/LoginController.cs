using System.Linq;
using System.Web.Http;
using Task.Models;

namespace Task.Controllers
{
    public class LoginController : ApiController
    {
        TODODBEntities db = new TODODBEntities();

        [HttpPost]
        public IHttpActionResult Login([FromBody] User login)
        {
            var user = db.Users.FirstOrDefault(x =>
                x.Username == login.Username &&
                x.Password == login.Password);

            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(user);
        }
    }
}