using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRoleService
{
    List<Role> GetAll();
    bool Add(RequestRole role);
    bool Update(int id, RequestRole role);
    bool Delete(int id);
}

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public List<Role> GetAll() => _roleRepository.QueryAll().ToList();

    public bool Add(RequestRole role)
    {
        var newRole = new Role(){
            CreateTime = DateTime.Now,
            CreateUser = ""
        };
        ObjectLibrary.CopyProperties(role, newRole);
        return _roleRepository.Create(newRole);
    }

    public bool Update(int id, RequestRole role)
    {
        var updateRole = new Role();
        ObjectLibrary.CopyProperties(role, updateRole);
        return _roleRepository.Update(id, updateRole);
    }

    public bool Delete(int id) => _roleRepository.Delete(id);
}