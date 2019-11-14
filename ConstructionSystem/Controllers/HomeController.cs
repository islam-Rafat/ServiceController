using ConstructionSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionSystem.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            //IdentityRole client = new IdentityRole();
            //client.Name = "Client";

            //RoleManager<IdentityRole> roleManager =
            //    new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //roleManager.Create(client);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}