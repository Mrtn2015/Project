using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Abstraction;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("specificdomain")]
    public class StoreController : Controller
    {
  
        IUnitOfWork uow;
        public StoreController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        [HttpGet]
       public IEnumerable<Product> Get()
        {
            return uow.ProductRepo.GetAll();
        }
        [HttpPost]
        public int Post([FromBody]Cart cart)
        {
            return uow.OrderRepo.SaveCart(cart);
        }

    }
}
