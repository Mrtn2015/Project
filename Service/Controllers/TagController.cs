using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstraction;

namespace Service.Controllers
{
    [EnableCors("specificdomain")]
    public class TagController : Controller
    {
        private IUnitOfWork uow;
        public TagController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [Route("api/tag/add")]
        public IActionResult Add([FromBody]TagModel tagModel)
        {
            try
            {
                var tag = new Tag();
                tag.Name = tagModel.Name;
                tag.Description = tagModel.Description;
                uow.TagRepo.Add(tag);
                uow.SaveChanges();
                return Ok();
            }
            catch 
            {
                return NotFound();
            }
        }

    }
}