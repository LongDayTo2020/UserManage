using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IAuthorizationService
{
    List<RoleRoleGroupRelationship> GetAll();
    bool Add(RequestAuthorization roleRoleGroupRelationship);
    bool Update(int id, RequestAuthorization roleRoleGroupRelationship);
    bool Delete(int id);
}

public class AuthorizationService : IAuthorizationService
{
    private readonly IRoleRoleGroupRelationshipRepository _roleRoleGroupRelationshipRepository;

    public AuthorizationService(IRoleRoleGroupRelationshipRepository roleRoleGroupRelationshipRepository)
    {
        _roleRoleGroupRelationshipRepository = roleRoleGroupRelationshipRepository;
    }

    public List<RoleRoleGroupRelationship> GetAll() => _roleRoleGroupRelationshipRepository.QueryAll().ToList();

    public bool Add(RequestAuthorization roleRoleGroupRelationship)
    {
        var newRoleRoleGroupRelationship = new RoleRoleGroupRelationship();
        ObjectLibrary.CopyProperties(roleRoleGroupRelationship, newRoleRoleGroupRelationship);
        return _roleRoleGroupRelationshipRepository.Create(newRoleRoleGroupRelationship);
    }


    public bool Update(int id, RequestAuthorization roleRoleGroupRelationship)
    {
        var updateRoleRoleGroupRelationship = new RoleRoleGroupRelationship();
        ObjectLibrary.CopyProperties(roleRoleGroupRelationship, updateRoleRoleGroupRelationship);
        return _roleRoleGroupRelationshipRepository.Update(id, updateRoleRoleGroupRelationship);
    }

    public bool Delete(int id) => _roleRoleGroupRelationshipRepository.Delete(id);
}