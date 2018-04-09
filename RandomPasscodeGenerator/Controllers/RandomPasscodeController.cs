using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RandomPasscode.Controllers{
    public class RandomPasscodeController : Controller{
        public int GenCount = 1;
        public string passcode;
        public string[] alphanum = new string[] {"0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","X","Y","Z"};
        [HttpGet]
        [Route("")]
        public IActionResult Index(int count){
            int? IntVariable = HttpContext.Session.GetInt32("count");
            if (IntVariable == null){
                IntVariable = 1;
            }
            HttpContext.Session.SetInt32("count", (int)IntVariable);
            ViewBag.GenCount = IntVariable;
            Random rand = new Random();
            for(int i = 0; i<14; i++){
                int idx = rand.Next(0,36);
                passcode += alphanum[idx];
            }
            ViewBag.Passcode = passcode;
            return View("Index");
        }
        [HttpPost]
        [Route("generate")]
        public IActionResult PassCode(){
            int? IntVariable = HttpContext.Session.GetInt32("count");
            HttpContext.Session.SetInt32("count", (int)IntVariable + 1);
            return RedirectToAction("Index");
        }
    }
}