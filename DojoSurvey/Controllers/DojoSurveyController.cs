using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers{
    public class DojoSurveyController : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }
        [HttpPost]
        [Route("survey")]
        public IActionResult Survey(string name, string dojolocation, string favoritelanguage, string comment){
            ViewBag.FavLang = favoritelanguage;
            ViewBag.Name = name;
            ViewBag.Dojo = dojolocation;
            ViewBag.Comment = comment;
            return View("Result");
        }
        // [HttpGet]
        // [Route("/result")]
        // public IActionResult Result(){
        //     ViewBag.Survey = Survey;
        //     return View("Result");
        // }
    }
}