using CleanArchitecture.Domain;

namespace CleanArchitechure.InMemoryDB;

public class InMemoryUserGateway : IUserGateway
{
    List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public IEnumerable<User> FindAllUsers()
    {
        return _users;
    }
}