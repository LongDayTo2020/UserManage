using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserGroupService
{
    List<UserGroup> GetAll();
    bool Add(UserGroup userGroup);
    bool Update(int id, UserGroup userGroup);
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

    public bool Add(UserGroup userGroup) => _userGroupRepository.Create(userGroup);

    public bool Update(int id, UserGroup userGroup) => _userGroupRepository.Update(id, userGroup);

    public bool Delete(int id) => _userGroupRepository.Delete(id);
}