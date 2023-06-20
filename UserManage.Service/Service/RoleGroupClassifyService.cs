using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IRoleGroupClassifyService
{
    List<RoleRoleGroupRelationship> GetAll();
    bool Add(RequestRoleGroupClassify request);
    bool Delete(RequestRoleGroupClassify request);
}

public class RoleGroupClassifyService : IRoleGroupClassifyService
{
    private readonly IRoleRoleGroupRelationshipRepository _roleRoleGroupRelationshipRepository;

    public RoleGroupClassifyService(IRoleRoleGroupRelationshipRepository roleRoleGroupRelationshipRepository)
    {
        _roleRoleGroupRelationshipRepository = roleRoleGroupRelationshipRepository;
    }

    public List<RoleRoleGroupRelationship> GetAll() => _roleRoleGroupRelationshipRepository.QueryAll().ToList();

    public bool Add(RequestRoleGroupClassify request)
    {
        var newUserRoleGroup = new RoleRoleGroupRelationship()
        {
            CreateTime = DateTime.Now,
            CreateUser = ""
        };

        ObjectLibrary.CopyProperties(request, newUserRoleGroup);
        return _roleRoleGroupRelationshipRepository.Create(newUserRoleGroup);
    }

    public bool Delete(RequestRoleGroupClassify request)
    {
        var newUserRoleGroup = new RoleRoleGroupRelationship();
        ObjectLibrary.CopyProperties(request, newUserRoleGroup);
        return _roleRoleGroupRelationshipRepository.Delete(newUserRoleGroup);
    }
}