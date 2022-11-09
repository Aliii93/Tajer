using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TajerTest.Controllers;
using TajerTest.Models;

namespace TajerTest.AuthFilter
{

    public class AuthFilter : ActionFilterAttribute
    {
        public AuthFilter(int permission)
        {
            this._permission = permission;
        }
        private int _permission;

        public AuthFilter() { }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            TajerContext tajerContext = new TajerContext();
            var RoleId = tajerContext.UserRoles.Where(x => x.UserId == BaseController.userId).Select(x => x.RoleId).FirstOrDefault();
            var Permission =tajerContext.PermissionRoles.Where(x => x.RoleId == RoleId && x.PermissonId == this._permission).FirstOrDefault();
            if (Permission != null)
            {

            }
            else
            {
                filterContext.Result = new OkObjectResult("UnAuthorized User") ;
            }
        }
    }
}
