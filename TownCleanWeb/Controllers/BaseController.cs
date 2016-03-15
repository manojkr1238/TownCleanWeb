using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownCleanWeb.Models;

namespace TownCleanWeb.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();                
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string Name = string.Concat(new string[] { user.FName });
                    ViewBag.UserDisplayName = Name;
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}