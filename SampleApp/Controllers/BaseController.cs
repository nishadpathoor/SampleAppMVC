using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SampleApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        public ClaimsPrincipal LoggedUser
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication.User;
            }
        }
        public bool HasPersmission(params string[] roles)
        {
            return roles.Any(n => LoggedUser.IsInRole(n));
        }

        public List<string> GetRoles()
        {
            var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
            return roles;
        }

    }
}