using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IPermissionService
{
    List<Permission> GetAll();
    bool Add(Permission permission);
    bool Update(int id, Permission permission);
    bool Delete(int id);
}

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public List<Permission> GetAll() => _permissionRepository.QueryAll().ToList();

    public bool Add(Permission permission) => _permissionRepository.Create(permission);

    public bool Update(int id, Permission permission) => _permissionRepository.Update(id, permission);

    public bool Delete(int id) => _permissionRepository.Delete(id);
}