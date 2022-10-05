using Microsoft.AspNetCore.Mvc;

namespace DafDev.FootballManagerNot.GroupManagement.Web.Controllers;

[Route("groups")]
public class GroupsController : Controller
{
    [HttpGet]
    [Route("")]
    public IActionResult Index() 
    {
        return Content("Groups management page WIP");
    }
}
