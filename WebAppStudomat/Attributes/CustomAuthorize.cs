using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppStudomat.Models.Users;

namespace WebAppStudomat.Attributes
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly UserRoles[] allowedRoles;
        private readonly string userRoleProperty = nameof(User.UserRole);

        public CustomAuthorize(params UserRoles[] roles)
        {
            this.allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var userRoleSession = HttpContext.Current.Session[userRoleProperty];
            if (userRoleSession != null)
            {
                var userRole = (UserRoles)userRoleSession;
                foreach (var role in allowedRoles)
                {
                    if (role == userRole)
                    {
                        return true;
                    }
                }
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "Login"},
                    { "controller", "Home"}
                });
        }
    }
}