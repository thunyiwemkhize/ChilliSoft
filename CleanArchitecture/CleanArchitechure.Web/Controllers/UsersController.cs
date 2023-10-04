using CleanArchitecture.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitechure.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private ICreateUserUseCase _createUserUseCase;

        private readonly ILogger<UsersController> _logger;

        public UsersController(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase =  createUserUseCase;
        }

        [HttpPost]
        public CreateUserResponse Post(CreateUserRequest request)
        {
            var presenter = new RestPresenter(this);
            _createUserUseCase.Execute(request, presenter);
            return presenter.Render();

        }

        public class RestPresenter : IPresenter
        {
            private readonly ControllerBase _controller;
            private readonly CreateUserResponse _response;
            private readonly string _error;
            public RestPresenter(ControllerBase controller)
            {
                _controller = controller;
            }

            public void Success(CreateUserResponse response)
            {
                response = _response;
            }

            public void Error(string error)
            {
                error = _error;
            }

            public CreateUserResponse Render()
            {
                return _response;
            }
        }
    }
}