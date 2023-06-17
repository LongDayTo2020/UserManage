using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRoleRoleGroupRelationshipService
{
    List<RoleRoleGroupRelationship> GetAll();
    bool Add(RoleRoleGroupRelationship roleRoleGroupRelationship);
    bool Update(int id, RoleRoleGroupRelationship roleRoleGroupRelationship);
    bool Delete(int id);
}

public class RoleRoleGroupRelationshipService : IRoleRoleGroupRelationshipService
{
    private readonly IRoleRoleGroupRelationshipRepository _roleRoleGroupRelationshipRepository;

    public RoleRoleGroupRelationshipService(IRoleRoleGroupRelationshipRepository roleRoleGroupRelationshipRepository)
    {
        _roleRoleGroupRelationshipRepository = roleRoleGroupRelationshipRepository;
    }

    public List<RoleRoleGroupRelationship> GetAll() => _roleRoleGroupRelationshipRepository.QueryAll().ToList();

    public bool Add(RoleRoleGroupRelationship roleRoleGroupRelationship) => _roleRoleGroupRelationshipRepository.Create(roleRoleGroupRelationship);

    public bool Update(int id, RoleRoleGroupRelationship roleRoleGroupRelationship) => _roleRoleGroupRelationshipRepository.Update(id, roleRoleGroupRelationship);

    public bool Delete(int id) => _roleRoleGroupRelationshipRepository.Delete(id);
}