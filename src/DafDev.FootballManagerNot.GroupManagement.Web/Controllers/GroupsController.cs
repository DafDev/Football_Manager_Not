using DafDev.FootballManagerNot.GroupManagement.Contracts.Services;
using DafDev.FootballManagerNot.GroupManagement.Web.Models;
using DafDev.FootballManagerNot.GroupManagement.Web.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace DafDev.FootballManagerNot.GroupManagement.Web.Controllers;

[Route("groups")]
public class GroupsController : Controller
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index() => View(_groupService.GetAll().ToViewModel());

    [HttpGet]
    [Route("users")]
    public string AddUser(string name, int id = 0) => HtmlEncoder.Default.Encode($"User {name} with id {id} has been added.");

    [HttpGet]
    [Route("{id}")]
    public IActionResult Details(int id)
    {
        var group = _groupService.GetById(id);

        if (group is null)
            return NotFound();

        return View(group.ToViewModel());
    }

    [HttpPost]
    [Route("{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(GroupViewModel editGroup)
    {
        if (editGroup is null)
            return BadRequest();

        var group = _groupService.Update(editGroup.ToServiceModel());

        if (group is null)
            return NotFound();

        group.Name = editGroup.Name;

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("create")]
    public IActionResult Create() => View();

    [HttpPost]
    [Route("create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(GroupViewModel model)
    {
        if (model == null)
            return BadRequest();

        _groupService.Add(model.ToServiceModel());

        return RedirectToAction("Index");
    }
}
