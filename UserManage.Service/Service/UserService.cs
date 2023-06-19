using UserManage.Library;
using UserManage.Library.ViewModel.Request;
using UserManage.Library.ViewModel.Response;
using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserService
{
    List<User> GetAll();
    bool Add(RequestUser user);
    bool Update(int id, RequestUser user);
    bool Delete(int id);
    ResponseUser? GetUser(int id);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAll() => _userRepository.QueryAll().ToList();

    public ResponseUser? GetUser(int id)
        => _userRepository.QueryAll()
            .Where(x => x.Id == id)
            .Select(q =>
            {
                var responseUser = new ResponseUser();
                ObjectLibrary.CopyProperties(q, responseUser);
                return responseUser;
            }).FirstOrDefault();

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
}