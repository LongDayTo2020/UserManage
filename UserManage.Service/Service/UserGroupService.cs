using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserGroupService
{
    List<UserGroup> GetAll();
    bool Add(RequestUserGroup userGroup);
    bool Update(int id, RequestUserGroup userGroup);
    bool Delete(int id);
}

public class UserGroupService : IUserGroupService
{
    private readonly IUserGroupRepository _userGroupRepository;

    public UserGroupService(IUserGroupRepository userGroupRepository)
    {
        _userGroupRepository = userGroupRepository;
    }

    public List<UserGroup> GetAll() => _userGroupRepository.QueryAll().ToList();

    public bool Add(RequestUserGroup request)
    {
        var addUserGroup = new UserGroup()
        {
            CreateTime = DateTime.Now,
            CreateUser = ""
        };
        ObjectLibrary.CopyProperties(request, addUserGroup);
        return _userGroupRepository.Create(addUserGroup);
    }


    public bool Update(int id, RequestUserGroup request) 
    {
        var updateUserGroup = new UserGroup()
        {
            UpdateTime = DateTime.Now,
            UpdateUser = ""
        };
        ObjectLibrary.CopyProperties(request, updateUserGroup);
        return _userGroupRepository.Update(id, updateUserGroup);
    }

    public bool Delete(int id) => _userGroupRepository.Delete(id);
}