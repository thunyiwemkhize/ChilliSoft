namespace CleanArchitecture.Domain;

public class CreateUserUseCase
{
    private IUserGateway _userGateway;
    public CreateUserUseCase(IUserGateway userGateway)
    {
        _userGateway = userGateway;
    }
  
    public User Execute(CreateUserRequest request)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = request.EmailAddress
        };
        _userGateway.AddUser(newUser);
        return newUser;
    }
}
