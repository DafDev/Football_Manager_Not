using DafDev.FootballManagerNot.GroupManagement.Contracts.Models;
namespace DafDev.FootballManagerNot.GroupManagement.Contracts.Services;

public interface IGroupService
{
    IReadOnlyCollection<Group> GetAll();
    Group? GetById(int id);
    Group? GetByName(string name);
    Group? Update(Group group);
    Group Add(Group group);
    bool Delete(Group group);
}
