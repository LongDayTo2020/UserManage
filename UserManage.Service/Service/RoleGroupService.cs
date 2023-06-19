using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRoleGroupService
{
    List<RoleGroup> GetAll();
    bool Add(RequestRoleGroup roleGroup);
    bool Update(int id, RequestRoleGroup roleGroup);
    bool Delete(int id);
}

public class RoleGroupService : IRoleGroupService
{
    private readonly IRoleGroupRepository _roleGroupRepository;

    public RoleGroupService(IRoleGroupRepository roleGroupRepository)
    {
        _roleGroupRepository = roleGroupRepository;
    }

    public List<RoleGroup> GetAll() => _roleGroupRepository.QueryAll().ToList();

    public bool Add(RequestRoleGroup roleGroup)
    {
        var newRoleGroup = new RoleGroup(){
            CreateTime = DateTime.Now,
            CreateUser = ""
        };
        ObjectLibrary.CopyProperties(roleGroup, newRoleGroup);
        return _roleGroupRepository.Create(newRoleGroup);
    }

    public bool Update(int id, RequestRoleGroup roleGroup)
    {
        var updateRoleGroup = new RoleGroup(){
            UpdateTime = DateTime.Now,
            UpdateUser = ""
        };
        ObjectLibrary.CopyProperties(roleGroup, updateRoleGroup);
        return _roleGroupRepository.Update(id, updateRoleGroup);
    }

    public bool Delete(int id) => _roleGroupRepository.Delete(id);
}