namespace CleanArchitecture.Domain;

public class CreateUserUseCase
{
    private IUserGateway _userGateway;
    public CreateUserUseCase(IUserGateway userGateway)
    {
        _userGateway = userGateway;
    }
  
    public CreateUserResponse Execute(CreateUserRequest request)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = request.EmailAddress
        };
        _userGateway.AddUser(newUser);
        return new CreateUserResponse()
        {
            Id = newUser.Id
        };
    }

    public void Execute(CreateUserRequest request, IPresenter presenter)
    {
        if (!request.EmailAddress.Contains("@"))
        {
            presenter.Error("Invalid email address");
        }
        else
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = request.EmailAddress
            };
            _userGateway.AddUser(newUser);
            var response = new CreateUserResponse()
            {
                Id = newUser.Id
            };
            presenter.Success(response);
        }
       
    }

}
