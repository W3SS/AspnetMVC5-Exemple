﻿using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ModuloCongresso.Infra.CrossCutting.MvcFilters
{
    public class ClaimsAuthorizeAtribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAtribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            if (claim != null)
            {
                return claim.Value.Contains(_claimValue);
            }

            return false;
        }   
    }
}
