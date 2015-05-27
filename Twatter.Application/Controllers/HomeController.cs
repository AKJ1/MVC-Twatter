using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twatter.Application.Models;
using Twatter.Data.UnitOfWork;
using Twatter.Models;

namespace Twatter.Application.Controllers
{
    public class HomeController : Controller
    {
        private TwatterData data = new TwatterData();

        [Route("/{username}")]
        public ActionResult Index(string username = null)
        {
            if (username != null)
            {
                TwattViewModel viewModel = new TwattViewModel();
                viewModel.Twatts = (data.TwattRepository.Get(t => t.Poster.UserName == username)
                    .Take(50)
                    .OrderByDescending(t => t.TwattDate)
                    .ToList());

                return View(new TwattModel()
                {
                    ViewModel = viewModel
                });
            }
            else if (Request.IsAuthenticated)
            {
                username = User.Identity.GetUserName();
                TwattViewModel viewModel = new TwattViewModel();
                viewModel.Twatts = data.TwattRepository.Get(t => t.Poster.UserName == username)
                    .Take(50)
                    .OrderByDescending(t => t.TwattDate)
                    .ToList();

                return View(new TwattModel()
                {
                    ViewModel = viewModel
                });
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
           return View()
            ;
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