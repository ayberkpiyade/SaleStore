﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleStore.Models.ViewModels;
using SaleStore.Data;
using SaleStore.Models;
using PagedList.Core;

namespace SaleStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        HomePageViewModels model = new HomePageViewModels();
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index(int page = 1)
        {
            
            model.Categories = _context.Categories.ToPagedList<Category>(page, 10);
            model.Campaigns = _context.Campaigns.ToPagedList<Campaign>(page, 10);
            model.Products = _context.Products.ToPagedList<Product>(page, 10);
            model.Settings = _context.Setting.ToList();
            Setting settings = new Setting();
            settings = _context.Setting.FirstOrDefault();
            ViewBag.logo = settings.Logo;
            ViewBag.Title = settings.Title;
            ViewBag.phone = settings.Phone;
            ViewBag.SeoDescription = settings.SeoDescription;
            ViewBag.SeoKeywords = settings.SeoKeywords;
            ViewBag.SeoTitle = settings.SeoTitle;
            ViewBag.Adress = settings.Address;
            ViewBag.Mail = settings.Mail;
            ViewBag.SiteSlogan = settings.SiteSlogan;
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Campaigns()
        {
         

            return View();
        }
        public IActionResult Products(int page=1)
        {
            model.Categories = _context.Categories.ToPagedList<Category>(page, 10);
            model.Campaigns = _context.Campaigns.ToPagedList<Campaign>(page, 10);
            model.Products = _context.Products.ToPagedList<Product>(page, 10);
            model.Settings = _context.Setting.ToList();
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        //public IActionResult LastAddedProducts()
        //{
        //    List<Product> lastProducts;
        //    if (model != null)
        //    {
        //        //lastProducts = _context.Products.OrderByDescending(p => p.UpdateDate).ToList();
        //        lastProducts = model.Products.OrderByDescending(p => p.UpdateDate).ToList();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //    return View("Index", lastProducts);
        //}

    }
    
}
