using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainsModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstraction;

namespace UI.Areas.SuperAdmin.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork _uow): base(_uow)
        {

        }
        public IActionResult Index()
        {
            return View(uow.CategoryRepo.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                uow.CategoryRepo.Add(model);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            try
            {
                return View(uow.CategoryRepo.GetById(id));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            try
            {
                model.UpdatedDate = DateTime.Now;
                uow.CategoryRepo.Modify(model);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            uow.CategoryRepo.DeleteById(id);
            uow.SaveChanges();
            return RedirectToAction("index");
        }
    }
}