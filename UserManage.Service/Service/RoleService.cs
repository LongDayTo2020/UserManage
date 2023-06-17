using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRoleService
{
    List<Role> GetAll();
    bool Add(Role role);
    bool Update(int id, Role role);
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

    public bool Add(Role role) => _roleRepository.Create(role);

    public bool Update(int id, Role role) => _roleRepository.Update(id, role);

    public bool Delete(int id) => _roleRepository.Delete(id);
}