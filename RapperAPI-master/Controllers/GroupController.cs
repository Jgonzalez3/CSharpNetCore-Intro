using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
        [HttpGet]
        [Route("/groups/")]
        public JsonResult DisplayAllGroups(){
            return Json(allGroups);
        }
        [HttpGet]
        [Route("/groups/name/{name}/")]
        public JsonResult DisplayGroupName(string name, bool displayArtists){
            var groupname = from match in allGroups where match.GroupName == $"{name}" select new {match.Id, match.GroupName, match.Members};
            return Json(groupname);
        }
        [HttpGet]
        [Route("/groups/id/{id}/")]
        public JsonResult DisplayGroupId(int id){
            var groupid = from match in allGroups where match.Id == id select new {match.Id, match.GroupName, match.Members};
            return Json(groupid);
        }

    }
}