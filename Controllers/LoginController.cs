using Microsoft.AspNetCore.Mvc;
using TajerTest.Models;

namespace TajerTest.Controllers
{
    public class LoginController : BaseController
    {
        [HttpPost]
        [Route("[action]")]
        public object Login(string username, string Password)
        {
            TajerContext tajerContext = new TajerContext();
            var user = tajerContext.Users.FirstOrDefault(x => x.UserName == username && x.UserPassword == Password);

            if (user != null)
            {
                userId = user.Id;
                return "Login Successfully";
            }
            else
            {
                return "Check username or password";
            }
        }

        [HttpPost]
        [Route("[action]")]
        public object Logout()
        {
            
                userId = 0;
                return "LogOut Successfully";
            
            
        }
    }
}
