using CleanArchitechure.Web.Presenters;
using CleanArchitecture.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitechure.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        private readonly IActionResultPresenter _presenter;

        public UsersController(ICreateUserUseCase createUserUseCase, IActionResultPresenter presenter)
        {
            _presenter = presenter;
            _createUserUseCase =  createUserUseCase;
        }

        [HttpPost]
        public IActionResult Post(CreateUserRequest request)
        {
            _createUserUseCase.Execute(request, _presenter);
            return _presenter.Render();

        }

       
    }
}