namespace CleanArchitecture.Domain;

public interface IUserGateway
{
    void AddUser(User user);
    IEnumerable<User> FindAllUsers();
    int addTwoNumber();
}