using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        [HttpGet]
        [Route("/artists/")]
        public JsonResult DisplayAllArtists(){
            return Json(allArtists);
        }
        [HttpGet]
        [Route("/artists/name/{name}/")]
        public JsonResult DisplayArtistName(string name){
            var artname = from match in allArtists where match.ArtistName == $"{name}" select new {match.ArtistName, match.RealName, match.Age, match.Hometown, match.Group, match.GroupId};
            return Json(artname);
        }
        [HttpGet]
        [Route("/artists/realname/{name}/")]
        public JsonResult DisplayRealName(string name){
            var realname = from match in allArtists where match.RealName == $"{name}" select new {match.ArtistName, match.RealName, match.Age, match.Hometown, match.Group, match.GroupId};
            return Json(realname);
        }
        [HttpGet]
        [Route("/artists/hometown/{town}/")]
        public JsonResult DisplayHometown(string town){
            var hometown = from match in allArtists where match.Hometown == $"{town}" select new {match.ArtistName, match.RealName, match.Age, match.Hometown, match.Group, match.GroupId};
            return Json(hometown);
        }
        [HttpGet]
        [Route("/artists/groupid/{id}/")]
        public JsonResult DisplayGroupId(int id){
            var groupid = from match in allArtists where match.GroupId == id select new {match.ArtistName, match.RealName, match.Age, match.Hometown, match.Group, match.GroupId};
            return Json(groupid);
        }
    }
}