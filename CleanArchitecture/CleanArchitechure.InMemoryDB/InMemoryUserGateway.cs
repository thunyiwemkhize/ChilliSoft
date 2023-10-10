using CleanArchitecture.Domain;

namespace CleanArchitechure.InMemoryDB;

public class InMemoryUserGateway : IUserGateway
{
   readonly List<User> _users = new();

    public void AddUser(User user)
    {
        new UserValidation().ValidateUser(user);
        _users.Add(user);
    }

    public IEnumerable<User> FindAllUsers()
    {
        return _users;
    }
}