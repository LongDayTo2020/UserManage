using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IPermissionService
{
    List<Permission> GetAll();
    bool Add(RequestPermission permission);
    bool Update(int id, RequestPermission permission);
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

    public bool Add(RequestPermission permission)
    {
        var newPermission = new Permission();
        ObjectLibrary.CopyProperties(permission, newPermission);
        return _permissionRepository.Create(newPermission);
    }

    public bool Update(int id, RequestPermission permission)
    {
        var updatePermission = new Permission();
        ObjectLibrary.CopyProperties(permission, updatePermission);
        return _permissionRepository.Update(id, updatePermission);
    }

    public bool Delete(int id) => _permissionRepository.Delete(id);
}