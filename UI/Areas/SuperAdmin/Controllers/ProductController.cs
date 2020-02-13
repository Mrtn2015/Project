using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstraction;

namespace UI.Areas.SuperAdmin.Controllers
{
    public class ProductController : BaseController
    {

        IHostingEnvironment env;
        public ProductController(IUnitOfWork _uow, IHostingEnvironment _env):base(_uow)
        {
            env = _env;
        }
        void BindCategory()
        {
            ViewBag.CategoryList = uow.CategoryRepo.GetAll();
        }
        public IActionResult Index()
        {
            return View(uow.ProductRepo.GetAll());
        }
        public ActionResult Create()
        {
            BindCategory();
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
        //    try
         //   {
                var uploads = Path.Combine(env.WebRootPath, "uploads");
                bool exists = Directory.Exists(uploads);
                if (!exists)
                    Directory.CreateDirectory(uploads);
                var fileName = Path.GetFileName(model.File.FileName);
                var fileStream = new FileStream(Path.Combine(uploads, model.File.FileName), FileMode.Create);
                model.File.CopyToAsync(fileStream);
                model.ImageName = fileName;
                model.ImagePath = "/Uploads/" + fileName;

                Product data = new Product
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    ImagePath = model.ImagePath,
                    ImageName = model.ImageName
                   
                };
                uow.ProductRepo.Add(data);
                uow.SaveChanges();
                return RedirectToAction("Index");
           // }
           // catch(Exception ex)
           // {

            //}
            BindCategory();
            return View();
        }
        public ActionResult Edit (int id)
        {
            BindCategory();
            Product data = uow.ProductRepo.GetById(id);
            ProductModel model = new ProductModel();
            if (data != null)
            {
                model.ProductId = data.ProductId;
                model.Name = data.Name;
                model.UnitPrice = data.UnitPrice;
                model.CategoryId = data.CategoryId;
                model.Description = data.Description;
                model.ImagePath = data.ImagePath;
                model.ImageName = data.ImageName;
            }
            return View(model);
        }
    }
}