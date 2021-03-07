using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private ClaimsIdentity GetIdentity()
        {
            return HttpContext.User.Identity as ClaimsIdentity;
        }
        
        protected bool IsAdmin()
        {
            var identity = GetIdentity();
            if (identity == null)
            {
                return false;
            }

            return identity.FindFirst(ClaimNames.UserType)?.Value == nameof(UserTypes.Admin);
        }
    }
}