using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ApplicationCore;

namespace Service.Controllers
{
    [EnableCors("specificdomain")]
    public class AccountController : Controller
    {
        private readonly DatabaseContext db;
        private readonly UserManager<User> userManager;
        IUnitOfWork uow;
        public AccountController(IUnitOfWork _uow, UserManager<User> _userManager, DatabaseContext _db)
        {
            uow = _uow;
            userManager = _userManager;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/auth/validateuser")]
        [Route("api/auth/validateuser")]
        public async Task<UserModel> ValidateUser([FromBody]LoginModel model)
        {
            var result = await uow.AuthenticateRepo.ValidateUser(model);
            return result;
        }
        /*      [HttpPost]
              public async Task<IActionResult> SignUp(User model)
              {
                  var result = await userManager.CreateAsync(model, model.Password);
                  if (result.Succeeded)
                  {
                      // var role = await roleManager.FindByNameAsync("User");
                      var role = await roleManager.FindByNameAsync("SuperAdmin");
                      if (role != null)
                      {
                          var r = await userManager.AddToRoleAsync(model, role.Name);
                          if (r.Succeeded)
                          {
                              return RedirectToAction("Login");
                          }
                      }
                  }
                  return View();
              }*/

           [HttpPost]
           [Route("api/auth/registeruser")]
           public async Task<IActionResult> RegisterUser([FromBody]UserModel model, string role)
           {
            try
            {
                User user = new User();
                user.Name = model.Name;
                user.Password = model.Password;
                user.UserName = model.Username;
                user.CreatedDate = DateTime.Now;
                user.Address = model.Address;
                user.Email = model.Email;
                user.Linkedin = model.Linkedin;
                user.TagId = model.TagId;
                var result = await userManager.CreateAsync(user, user.Password);
                Role r1 = await uow.AuthenticateRepo.FindRole(role);
                // await userManager.UpdateSecurityStampAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, r1.Name);
                    return Ok(user);
                }
               
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/auth/updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody]UserModel model)
        {
           
            //      try { 
            var user = db.Users.Where(u => u.UserName == model.Username).FirstOrDefault();
            user.UserName = model.Username;
            user.Name = model.Name;
            user.Password = model.Password;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.Address = model.Address;
            return Ok(user);
            //            }
            //       catch (Exception ex)
            //     {
            //       return NotFound(ex.Message);
            //     }
        }
        [HttpGet]
        [Route("api/listusers")]
        public Task<IList<User>> ListUsers()
        {
          return uow.AuthenticateRepo.GetUsers();
        }
        [HttpGet]
        [Route("api/listlinkedin")]
        public List<string> ListLinkedin(string tagNames)
        {

           
            List<Tag> tags;
            if (!string.IsNullOrWhiteSpace(tagNames)) {
                List<string> tagNamesList = new List<string>();
                foreach (string t in tagNames.Split(',')) {
                    tagNamesList.Add(t.Trim());
                }
                tags = db.Tags.Where(t => tagNamesList.Contains(t.Name)).ToList();
            }
            else
            {
                tags = db.Tags.ToList();
            }
            IList<User> users = this.ListUsers().Result;
            List<User> usersWithTag = users.Where(u => tags.Where(t => t.TagId == u.TagId).ToList().Count > 0).ToList();
            List<string> linkedins = usersWithTag.Select(u => u.Linkedin).ToList();
            return linkedins;
        }

        [HttpGet]
        [Route("api/listroles")]
        public Task<List<Role>> ListRoles()
        {
            var roles = uow.ListRoles();
            return roles;
        }
        [HttpGet]
        [Route("api/listtags")]
        public List<Tag> ListTags()
        {
            var tags = db.Tags.ToList();
            return tags;
        }
    }
}