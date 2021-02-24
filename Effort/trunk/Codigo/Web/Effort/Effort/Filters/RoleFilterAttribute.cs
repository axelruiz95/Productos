﻿using Effort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Effort.Filters
{
    public class RoleFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Validar la información que se encuentra en la sesión.
            if ( ((Equipo) HttpContext.Current.Session["Login"]).perfil.Equals("Usuario") )
            {
                // Si la información es nula, redireccionar a 
                // página de error u otra página deseada.
                var parameters = filterContext.HttpContext.Request.QueryString.ToString();
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "Controller", "Account" },
                    { "Action", "NotAccess" }
            });
            }

            base.OnActionExecuting(filterContext);
        }       
    }
}