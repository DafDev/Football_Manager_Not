using DafDev.FootballManagerNot.GroupManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace DafDev.FootballManagerNot.GroupManagement.Web.Controllers;

[Route("groups")]
public class GroupsController : Controller
{
    private int _currentGroupId = 1;
    private static readonly List<Group> groups = new() { new() { Id = 225, Name = "Atlas" } };

    [HttpGet]
    [Route("")]
    public IActionResult Index() => View(groups);

    [HttpGet]
    [Route("users")]
    public string AddUser(string name, int id = 0) => HtmlEncoder.Default.Encode($"User {name} with id {id} has been added.");

    [HttpGet]
    [Route("{id}")]
    public IActionResult Details(int id)
    {
        var group = groups.SingleOrDefault(g => g.Id == id);

        if (group is null)
            return NotFound();

        return View(group);
    }

    [HttpPost]
    [Route("{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Group editGroup)
    {
        var group = groups.SingleOrDefault(g => g.Id == id);

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
    public IActionResult Create(Group model)
    {
        model.Id = ++_currentGroupId;
        groups.Add(model);

        return RedirectToAction("Index");
    }
}
