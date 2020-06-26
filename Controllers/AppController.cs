using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailServices _mailServices;
        private readonly IDutchRepository _dutchRepository;
        //      private readonly DutchContext ctx;

        public AppController(IMailServices mailServices, IDutchRepository dutchRepository)//,DutchContext ctx)
        {
            _mailServices = mailServices;
            _dutchRepository = dutchRepository;
            //    this.ctx = ctx;
        }
        public IActionResult Index()
        {
            //          var results = this.ctx.Products.ToList();
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailServices.SendMessage("krgalj@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message:{model.Message}");
                ViewBag.UserMessage = "Mail Send";
                ModelState.Clear();
            }


            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            var results = _dutchRepository.GetAllProducts();

            return View(results);
        }
        [Authorize]
        [HttpDelete("Shop")]
        public IActionResult Shop(Object model)
        {

            return View();
        }

    }
}
