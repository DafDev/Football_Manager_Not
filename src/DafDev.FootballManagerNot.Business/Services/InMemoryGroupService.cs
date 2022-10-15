using DafDev.FootballManagerNot.GroupManagement.Contracts.Models;
using DafDev.FootballManagerNot.GroupManagement.Contracts.Services;

namespace DafDev.FootballManagerNot.Business.Services;

public class InMemoryGroupService : IGroupService
{
    private int _currentId = 0;
    private readonly List<Group> _groups = new();

    public Group Add(Group group)
    {
        group.Id = ++_currentId;
        _groups.Add(group);
        return group;
    }

    public IReadOnlyCollection<Group> GetAll() => _groups.AsReadOnly();

    public Group? GetById(int id) => _groups.SingleOrDefault(g => g.Id == id);

    public Group? GetByName(string name) => _groups.SingleOrDefault(g => g.Name == g.Name);

    public Group? Update(Group group)
    {
        var toUpdate = GetById(group.Id);
        if(toUpdate != null)
            toUpdate.Name = group.Name;


        return toUpdate;
    }
}
