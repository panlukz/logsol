﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LogisticSolutions.DAL;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = userManager.FindById(currentUserId);


            if (currentUser != null)
            {
                ViewBag.UserLocation = currentUser.UserInfo.Location;
                ViewBag.UserRole = "Dupa nie działa :-(";

            }
            else
            {
                ViewBag.UserLocation = "Niezalogowany";
                ViewBag.UserRole = "Niezalogowany";
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}