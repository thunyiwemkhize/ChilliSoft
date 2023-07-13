namespace CleanArchitecture.Domain;

public class CreateUserUseCase
{
    private IUserGateway _userGateway;
    public CreateUserUseCase(IUserGateway userGateway)
    {
        _userGateway = userGateway;
    }
    public User Execute(string emailAddress)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = emailAddress
        };
        _userGateway.AddUser(newUser);
        return newUser;
    }
}