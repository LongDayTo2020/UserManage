using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IAuthorizationService
{
    List<RolePermissionRelationship> GetAll();
    bool Add(RequestAuthorization roleRoleGroupRelationship);
    bool Update(int id, RequestAuthorization roleRoleGroupRelationship);
    bool Delete(int id);
}

public class AuthorizationService : IAuthorizationService
{
    private readonly IRolePermissionRelationshipRepository _rolePermissionRelationshipRepository;

    public AuthorizationService(IRolePermissionRelationshipRepository rolePermissionRelationshipRepository)
    {
        _rolePermissionRelationshipRepository = rolePermissionRelationshipRepository;
    }

    public List<RolePermissionRelationship> GetAll() => _rolePermissionRelationshipRepository.QueryAll().ToList();

    public bool Add(RequestAuthorization roleRoleGroupRelationship)
    {
        var newRoleRoleGroupRelationship = new RolePermissionRelationship()
        {
            CreateTime = DateTime.Now,
            CreateUser = ""
        };
        ObjectLibrary.CopyProperties(roleRoleGroupRelationship, newRoleRoleGroupRelationship);
        return _rolePermissionRelationshipRepository.Create(newRoleRoleGroupRelationship);
    }


    public bool Update(int id, RequestAuthorization roleRoleGroupRelationship)
    {
        var updateRoleRoleGroupRelationship = new RolePermissionRelationship()
        {
            UpdateTime = DateTime.Now,
            UpdateUser = ""
        };
        ObjectLibrary.CopyProperties(roleRoleGroupRelationship, updateRoleRoleGroupRelationship);
        return _rolePermissionRelationshipRepository.Update(id, updateRoleRoleGroupRelationship);
    }

    public bool Delete(int id) => _rolePermissionRelationshipRepository.Delete(id);
}