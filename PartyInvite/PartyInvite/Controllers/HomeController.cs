using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvite.Models;

namespace PartyInvite.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
                Respository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else
            {
                return View();
            }
            
        }

        public ViewResult ListResponses()
        {
            return View(Respository.Respones.Where(r => r.WillAttend == true));
        }
    }
}
