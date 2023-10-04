namespace CleanArchitecture.Domain;

public class CreateUserUseCase: ICreateUserUseCase
{
    private IUserGateway _userGateway;
    public CreateUserUseCase(IUserGateway userGateway)
    {
        _userGateway = userGateway;
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
