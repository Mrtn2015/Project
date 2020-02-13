using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore;
using DomainsModel;
using DomainsModel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private DbContext db;
        public UnitOfWork(DatabaseContext _db, UserManager<User> _userManager, RoleManager<Role> _roleManager, SignInManager<User> _signInManager)
        {
            db = _db;
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }
        private ITagRepository _TagRepo;
        public ITagRepository TagRepo
        {
            get
            {
                if (_TagRepo == null)
                    _TagRepo = new TagRepository(db);
                    return _TagRepo;
                
            }
        }
        private IAuthenticateRepository _AuthenticateRepo;
        public IAuthenticateRepository AuthenticateRepo
        {
            get
            {
                if (_AuthenticateRepo == null)
                    _AuthenticateRepo = new AuthenticateRepository(db,userManager,roleManager,signInManager);
                return _AuthenticateRepo;
            }
        }
        private ICategoryRepository _CategoryRepo;
        public ICategoryRepository CategoryRepo { 
            get
            {
                if (_CategoryRepo == null)
                    _CategoryRepo = new CategoryRepository(db);
                return _CategoryRepo;
            }
        }
        private IProductRepository _ProductRepo;

        public IProductRepository ProductRepo { 
            get
            {
                if (_ProductRepo == null)
                    _ProductRepo = new ProductRepository(db);
                return _ProductRepo;
            }

        }
        private IOrderRepository _OrderRepo;
        public IOrderRepository OrderRepo {
            get
            {
                if (_OrderRepo == null)
                    _OrderRepo = new OrderRepository(db);
                return _OrderRepo;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        public Task<List<Role>> ListRoles()
        {
            var roles = roleManager.Roles.ToListAsync();
            return roles;
        }

    }
}
