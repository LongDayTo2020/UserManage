using UserManage.Repository.Entity;
using UserManage.Repository.Repository;

namespace UserManage.Service.Service;

public interface IUserService
{
    List<User> GetAll();
    bool Add(User user);
    bool Update(int id, User user);
    bool Delete(int id);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAll() => _userRepository.QueryAll().ToList();

    public bool Add(User user) => _userRepository.Create(user);

    public bool Update(int id, User user) => _userRepository.Update(id, user);

    public bool Delete(int id) => _userRepository.Delete(id);
}