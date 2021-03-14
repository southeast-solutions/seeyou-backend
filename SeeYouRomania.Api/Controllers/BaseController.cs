using System.Security.Claims;
using Amazon.SecurityToken.Model;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected string GetId()
        {
            return GetClaim(ClaimNames.UserId);
        }
        
        protected string GetUserType()
        {
            return GetClaim(ClaimNames.UserType);
        }
        
        protected bool IsAdmin()
        {
            return GetUserType() == nameof(UserTypes.Admin);
        }
        private ClaimsIdentity GetIdentity()
        {
            return HttpContext.User.Identity as ClaimsIdentity;
        }

        private string GetClaim(string claim)
        {
            var identity = GetIdentity();

            if (identity == null)
            {
                throw new InvalidIdentityTokenException("No token was passed as input");
            }

            return identity.FindFirst(claim).Value;
        }
    }
}