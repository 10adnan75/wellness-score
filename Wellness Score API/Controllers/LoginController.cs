using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wellness_Score_API.DataContext;
using Wellness_Score_API.Models;



namespace Wellness_Score_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<int> Login(Login login)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == login.UserName);
            if (user == null)
            {
                return Unauthorized(-1);
            }

            if (login.Password == user.Password)
            {
                if (user.Role == true)
                    return Ok(1);
                else
                    return Ok(0);
            }

            return Unauthorized(-1);
        }
    }
}