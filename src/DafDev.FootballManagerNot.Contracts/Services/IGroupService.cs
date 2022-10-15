using DafDev.FootballManagerNot.GroupManagement.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DafDev.FootballManagerNot.GroupManagement.Contracts.Services;

public interface IGroupService
{
    IReadOnlyCollection<Group> GetAll();
    Group? GetById(int id);
    Group? GetByName(string name);
    Group? Update(Group group);
    Group Add(Group group);
}
