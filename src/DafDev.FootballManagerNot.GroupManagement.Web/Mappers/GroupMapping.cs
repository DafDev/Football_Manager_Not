using DafDev.FootballManagerNot.GroupManagement.Contracts.Models;
using DafDev.FootballManagerNot.GroupManagement.Web.Models;
using System.Collections.ObjectModel;

namespace DafDev.FootballManagerNot.GroupManagement.Web.Mappers;

public static class GroupMapping
{
    public static GroupViewModel? ToViewModel(this Group group) => group != null ? new GroupViewModel { Id = group.Id, Name = group.Name } : null;
    public static Group? ToServiceModel(this GroupViewModel group) => group != null ? new Group { Id = group.Id, Name = group.Name } : null;

    public static IReadOnlyCollection<GroupViewModel> ToViewModel(this IReadOnlyCollection<Group> models)
    {
        if (models.Count == 0)
            return Array.Empty<GroupViewModel>();

        var groups = new GroupViewModel[models.Count];
        var i = 0;
        foreach (var model in models)
        {
            groups[i] = model.ToViewModel();
            ++i;
        }

        return new ReadOnlyCollection<GroupViewModel>(groups);
    }
}
