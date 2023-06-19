using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserClassifyService
{
    bool AddUserGroup(RequestUserGroup request);
    bool DeleteUserGroup(RequestUserGroup request);
}

/// <summary>
/// 會員分類角色群
/// </summary>
public class UserClassifyService : IUserClassifyService
{
    private readonly IUserRoleGroupRelationshipRepository _userRoleGroupRelationshipRepository;

    public UserClassifyService(IUserRoleGroupRelationshipRepository userRoleGroupRelationshipRepository)
    {
        _userRoleGroupRelationshipRepository = userRoleGroupRelationshipRepository;
    }

    public bool AddUserGroup(RequestUserGroup request)
    {
        var updateUser = new UserRoleGroupRelationship();
        ObjectLibrary.CopyProperties(request, updateUser);
        return _userRoleGroupRelationshipRepository.Create(updateUser);
    }

    public bool DeleteUserGroup(RequestUserGroup request)
    {
        var updateUser = new UserRoleGroupRelationship();
        ObjectLibrary.CopyProperties(request, updateUser);
        return _userRoleGroupRelationshipRepository.Create(updateUser);
    }
}