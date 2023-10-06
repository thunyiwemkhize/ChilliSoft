using CleanArchitecture.Domain;

namespace CleanArchitechure.InMemoryDB;

public class InMemoryUserGateway : IUserGateway
{
   readonly List<User> _users = new();

    public int addTwoNumber()
    {
        return 1;
    }

    public void AddUser(User user)
    {
        ValidateUser(user);
        _users.Add(user);
    }

    private static void ValidateUser(User user)
    {
        if (string.IsNullOrEmpty(user.Name))
        {
            throw new ArgumentNullException();
        }

        if (string.IsNullOrEmpty(user.Surname))
        {
            throw new ArgumentNullException();
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentNullException();
        }

        if (!user.Email.Contains('@'))
        {
            throw new ArgumentException("Invalid email address");
        }

        if (!user.Email.Contains('.'))
        {
            throw new ArgumentException("Invalid email address");
        }
    }

    public IEnumerable<User> FindAllUsers()
    {
        return _users;
    }
}