using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserService
{
    List<User> GetAll();
    bool Add(RequestUser user);
    bool Update(int id, RequestUser user);
    bool Delete(int id);
    bool UpdateUserGroup(int userId, RequestUserGroup request);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAll() => _userRepository.QueryAll().ToList();

    public bool Add(RequestUser user)
    {
        var newUser = new User();
        ObjectLibrary.CopyProperties(user, newUser);
        return _userRepository.Create(newUser);
    }

    public bool Update(int id, RequestUser user)
    {
        var updateUser = new User();
        ObjectLibrary.CopyProperties(user, updateUser);
        return _userRepository.Update(id, updateUser);
    }

    public bool Delete(int id) => _userRepository.Delete(id);
    
    public bool UpdateUserGroup(int userId, RequestUserGroup request)
    {
        throw new NotImplementedException();
    }
}