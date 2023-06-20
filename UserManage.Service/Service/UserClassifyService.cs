using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserIdentityClassifyService
{
    List<UserRoleGroupRelationship> GetAll();
    bool Add(RequestUserRoleGroup request);
    bool Delete(RequestUserRoleGroup request);
}

/// <summary>
/// 會員分類角色群
/// </summary>
public class UserIdentityClassifyService : IUserIdentityClassifyService
{
    private readonly IUserRoleGroupRelationshipRepository _userRoleGroupRelationshipRepository;

    public UserIdentityClassifyService(IUserRoleGroupRelationshipRepository userRoleGroupRelationshipRepository)
    {
        _userRoleGroupRelationshipRepository = userRoleGroupRelationshipRepository;
    }

    public List<UserRoleGroupRelationship> GetAll()
        => _userRoleGroupRelationshipRepository.QueryAll().ToList();

    public bool Add(RequestUserRoleGroup request)
    {
        var updateUser = new UserRoleGroupRelationship()
        {
            CreateTime = DateTime.Now,
            CreateUser = ""
        };
        ObjectLibrary.CopyProperties(request, updateUser);
        return _userRoleGroupRelationshipRepository.Create(updateUser);
    }

    public bool Delete(RequestUserRoleGroup request)
    {
        return _userRoleGroupRelationshipRepository.Delete(request);
    }
}