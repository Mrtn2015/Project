﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Security
{
    public class CustomAuthorize: Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!context.HttpContext.User.IsInRole(Roles))
                {
                    context.Result = new RedirectToActionResult("Unauthorize", "Account", new { area = "" });
                }
            }
            else
            {
                context.Result = new RedirectToActionResult("Login", "Account", new
                { area = "" });
            }
        }
    }
}
