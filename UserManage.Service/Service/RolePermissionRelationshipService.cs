using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRolePermissionRelationshipService
{
    List<RolePermissionRelationship> GetAll();
    bool Add(RolePermissionRelationship rolePermissionRelationship);
    bool Update(int id, RolePermissionRelationship rolePermissionRelationship);
    bool Delete(int id);
}

public class RolePermissionRelationshipService : IRolePermissionRelationshipService
{
    private readonly IRolePermissionRelationshipRepository _rolePermissionRelationshipRepository;

    public RolePermissionRelationshipService(IRolePermissionRelationshipRepository rolePermissionRelationshipRepository)
    {
        _rolePermissionRelationshipRepository = rolePermissionRelationshipRepository;
    }

    public List<RolePermissionRelationship> GetAll() => _rolePermissionRelationshipRepository.QueryAll().ToList();

    public bool Add(RolePermissionRelationship rolePermissionRelationship) => _rolePermissionRelationshipRepository.Create(rolePermissionRelationship);

    public bool Update(int id, RolePermissionRelationship rolePermissionRelationship) => _rolePermissionRelationshipRepository.Update(id, rolePermissionRelationship);

    public bool Delete(int id) => _rolePermissionRelationshipRepository.Delete(id);
}