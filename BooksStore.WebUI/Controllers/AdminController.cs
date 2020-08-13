using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//add
using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using BooksStore.WebUI.Models;

namespace BooksStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRespository repository;
        public int PageSize = 6;                //一页可以容纳多少条记录

        public AdminController(IProductsRespository repo)
        {
            repository = repo;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin lAdmin)
        {
            Admin admin = repository.Admins.SingleOrDefault(p => p.adminName == lAdmin.adminName);
            if (admin == null)
            {
                TempData["message"] = "你输入的用户不存在";
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                if(admin.pwd!=lAdmin.pwd)
                {
                    TempData["message"] = "你输入的密码是错误的";
                    return RedirectToAction("Login","Admin");
                }
                else
                {
                    //跳转到Admin控制器名为Index的Action
                    return RedirectToAction("Index", "Admin", new { page = 1 });
                }
            }
        }
       
        public ViewResult Index(int page)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },
            };
            return View(model);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} 保存成功了", product.Name);
                return RedirectToAction("Index", "Admin", new { page = 1 });
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} 已经被删除了",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index", "Admin", new { page=1});
        }
	}
}