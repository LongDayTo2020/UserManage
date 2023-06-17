using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRoleGroupService
{
    List<RoleGroup> GetAll();
    bool Add(RoleGroup roleGroup);
    bool Update(int id, RoleGroup roleGroup);
    bool Delete(int id);
}

public class RoleGroupService : IRoleGroupService
{
    private readonly IRoleGroupRepository _userRepository;

    public RoleGroupService(IRoleGroupRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<RoleGroup> GetAll() => _userRepository.QueryAll().ToList();

    public bool Add(RoleGroup roleGroup) => _userRepository.Create(roleGroup);

    public bool Update(int id, RoleGroup roleGroup) => _userRepository.Update(id, roleGroup);

    public bool Delete(int id) => _userRepository.Delete(id);
}