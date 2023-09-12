using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_MVC_Core.Models.Repository;
using ASP.NET_MVC_Core.Models;

namespace MongoDbCRUD.Controllers
{
    public class ProductController : Controller
    {
        private ProductCollection db = new ProductCollection();

        // GET: Product
        public ActionResult Index()
        {
            var data = db.GetAllProduct();
            return View(data);
        }
 
//The ActionResult class provides a way to encapsulate the result of an action method
//and return it to the user in the form of an HTTP response.
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.InsertContact(product);

            return RedirectToAction("Index", db.GetAllProduct());
        }

        [HttpGet]
        public ActionResult UpdateProduct(string productId)
        {
            var product = db.GetProductById(productId);

            return View("UpdateProduct", product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(string productId, Product product)
        {
            db.UpdateContact(productId, product);
            var allProduct = db.GetAllProduct();

            return RedirectToAction("Index", allProduct);
        }

        [HttpPost]
        public ActionResult DeleteProduct(string productId)
        {
            db.DeleteContact(productId);

            var all = db.GetAllProduct();
            return RedirectToAction("Index", all);
        }

    }
}
