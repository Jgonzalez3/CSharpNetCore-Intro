using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dojodachi.Controllers{
    public class DojodachiController : Controller{

        [HttpGet]
        [Route("/dojodachi")]
        public IActionResult Index(){
            int? Fullness = HttpContext.Session.GetInt32("fullness");
            if(Fullness == null){
                Fullness = 20;
            }
            HttpContext.Session.SetInt32("fullness", (int)Fullness);
            ViewBag.Full = Fullness;

            int? Happiness = HttpContext.Session.GetInt32("happiness");
            if(Happiness == null){
                Happiness = 20;
            }
            HttpContext.Session.SetInt32("happiness", (int)Happiness);
            ViewBag.Happy = Happiness;

            int? Energy = HttpContext.Session.GetInt32("energy");
            if(Energy == null){
                Energy = 20;
            }
            HttpContext.Session.SetInt32("energy", (int)Energy);
            ViewBag.Energy = Energy;

            int? Meals = HttpContext.Session.GetInt32("meals");
            if(Meals == null){
                Meals = 3;
            }
            HttpContext.Session.SetInt32("meals", (int)Meals);
            ViewBag.Meals = Meals;
            return View("Index");
        }

        [HttpPost]
        [Route("feed")]
        public IActionResult Feed(){
            int? Meals = HttpContext.Session.GetInt32("meals");
            int? Fullness = HttpContext.Session.GetInt32("happiness");
            if ((int)Meals == 0){
                TempData["message"] = $"You cannot feed your Dojodachi if you have {Meals} meals";
                return RedirectToAction("Index");
            }
            Random dislike = new Random();
            int hate = dislike.Next(1,5);
            HttpContext.Session.SetInt32("meals", (int)Meals-1);
            if( hate != 1){
                Random rand = new Random();
                int full = rand.Next(5,11);
                HttpContext.Session.SetInt32("fullness", (int)Fullness + full);
                TempData["message"] = $"You Feed your Dojodachi! Fullness +{full}, Meals -1";
            }
            else{
                TempData["message"] = $"You Feed your Dojodachi but it did not like it! Fullness +0, Meals -1";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("play")]
        public IActionResult Play(){
            int? Energy = HttpContext.Session.GetInt32("energy");
            if((int)Energy < 4){
                TempData["message"] = "Your Dojodachi does not have enough energy!";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetInt32("energy", (int)Energy-5);
            Random dislike = new Random();
            int hate = dislike.Next(1,5);
            if(hate !=1){
                Random rand = new Random();
                int happy = rand.Next(5,11);
                int? Happiness = HttpContext.Session.GetInt32("happiness");
                HttpContext.Session.SetInt32("happiness", (int)Happiness + happy);
                TempData["message"] = $"You Played with your Dojodachi! Happiness +{happy}, Energy -5";
            }
            else{
                TempData["message"] = $"You Played with your Dojodachi and it hated it! Happiness +0, Energy -5";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("work")]
        public IActionResult Work(){
            int? Energy = HttpContext.Session.GetInt32("energy");
            if((int)Energy < 4){
                TempData["message"] = "Your Dojodachi does not have enough energy!";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetInt32("energy", (int)Energy-5);
            int? Meals = HttpContext.Session.GetInt32("meals");
            Random rand = new Random();
            int food = rand.Next(1,4);
            HttpContext.Session.SetInt32("meals", (int)Meals+food);
            TempData["message"] = $"You Worked your Dojodachi! Energy -5 and gained +{food}";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep(){
            int? Energy = HttpContext.Session.GetInt32("energy");
            HttpContext.Session.SetInt32("energy", (int)Energy+15);
            int? Happiness = HttpContext.Session.GetInt32("happiness");
            HttpContext.Session.SetInt32("happiness", (int)Happiness-5);
            int? Fullness = HttpContext.Session.GetInt32("fullness");
            HttpContext.Session.SetInt32("fullness", (int)Fullness-5);
            if(Fullness-5 == 0 || Happiness-5 == 0){
                TempData["message"] = "Your Dojodachi has passed away..";
            }
            else{
                TempData["message"] = $"Your Dojodachi Slept! Energy +15, Fullness -5, Happiness-5";
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("restart")]
        public IActionResult Restart(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}