using ApplicationCore;
using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class AuthenticateRepository : Repository<User>, IAuthenticateRepository
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private DatabaseContext context
        {
            get
            {
                return this.db as DatabaseContext;
            }
        }
        public AuthenticateRepository(DbContext _db, UserManager<User> _userManager,RoleManager<Role> _roleManager, SignInManager<User> _signInManager)
        {
            this.db = _db;
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public Task<Role> FindRole(string role)
        {
            return roleManager.FindByNameAsync(role);
        }
        public async Task<UserModel> ValidateUser(LoginModel model)
        {
            //var d = context.Users.Where(u => u.UserName == model.UserName && u.Password == model.Password);
            //  User user = context.Users.Include(u=> u.Roles).AsEnumerable().Where(u => u.UserName == model.UserName).FirstOrDefault();
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user is null)
            {
                return null;
            }
            var roles = await userManager.GetRolesAsync(user);
            Boolean verifyPassword = await userManager.CheckPasswordAsync(user, model.Password);
            //User user = data.FirstOrDefault();
            if (user != null && verifyPassword)
            {
                UserModel obj = new UserModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.UserName,
                    Address = user.Address,
                    PhoneNumber = user.ContactNo,
                    Roles = roles.ToArray()

                };
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Task<IList<User>> GetUsers()
        {
            Task<Role> role = this.FindRole("User"); 
             //   db.Roles.Where(r => r.Id == 2).FirstOrDefault();
            var users = userManager.GetUsersInRoleAsync(role.Result.Name);
            return users;
        }
    }
}
