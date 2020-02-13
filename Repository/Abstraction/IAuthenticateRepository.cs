using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IAuthenticateRepository : IRepository<User>
    {
        Task<UserModel> ValidateUser(LoginModel model);
        Task<Role> FindRole(string role);
        Task<IList<User>> GetUsers();
    }
}
