using ConstructionSystem.Models;
using ConstructionSystem.Models.MyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace ConstructionSystem.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public IQueryable<ClientVM> AllClients()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var ClientList = (from user in db.Users
                              select new
                              {
                                  userId = user.Id,
                                  userName = user.UserName,
                                  email = user.Email,
                                  phone = user.PhoneNumber,
                                  city = user.City,
                                  age = user.Age,
                                  gender = user.Gender,
                                  role = (from clientRole in user.Roles
                                          join roles in db.Roles
                                          on clientRole.RoleId equals roles.Id
                                          where roles.Name == "Client"
                                          select roles.Name
                                        ).ToString()
                              }).Select(x => new ClientVM()
                              {
                                  userId = x.userId,
                                  userName = x.userName,
                                  email = x.email,
                                  phone = x.phone,
                                  city = x.city,
                                  age = x.age,
                                  gender = x.gender,
                                  role = x.role
                              });
            return ClientList;
        }

        // GET All Clients
        public JsonResult GetAllClients()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var Clients = AllClients().ToList();

            return Json(Clients, JsonRequestBehavior.AllowGet);
        }

        // Create Client

        [HttpPost]
        public async Task<JsonResult> CreateClient(ClientVM client)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = client.userName, Email = client.email, Age = client.age, City = client.city, PhoneNumber = client.phone, Gender = client.gender };
                var result = await UserManager.CreateAsync(user, client.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return Json(AllClients().ToList(), JsonRequestBehavior.AllowGet);
                }
                return Json(result.Errors, JsonRequestBehavior.AllowGet);
            }
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        // Edit Client
        [HttpGet]
        public JsonResult EditClient(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var client = AllClients().Where(x => x.userId == id).FirstOrDefault();

            return Json(client, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditClient(ClientVM clientVM)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Entry(clientVM).State = EntityState.Modified;
            db.SaveChanges();
            return Json(AllClients().ToList(), JsonRequestBehavior.AllowGet);
        }
         
        // Delete Client

        public JsonResult DeleteClient(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var client = db.Users.Where(x => x.Id == id).FirstOrDefault();

            db.Users.Remove(client);

            return Json(AllClients().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}