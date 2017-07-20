using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWebApi_Client.Models;
using CRUDWebApi_Client.ViewModels;

namespace CRUDWebApi_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductClient pc = new ProductClient();
            ViewBag.listProducts = pc.FindAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel pvm)
        {
            pvm.Product.CreationDate = DateTime.Now;
            ProductClient pc = new ProductClient();
            pc.Create(pvm.Product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductClient pc = new ProductClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = pc.Find(id);
            return View("Edit",pvm);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            ProductViewModel pvm = new ProductViewModel();
            
            ProductClient pc = new ProductClient();
          
            pc.Edit(pvm.Product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            
            ProductClient pc = new ProductClient();
            pc.Delete(id);
            return RedirectToAction("Index");
        }

    }
}