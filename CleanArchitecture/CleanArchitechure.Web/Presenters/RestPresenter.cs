using CleanArchitecture.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitechure.Web.Presenters
{
  
    public class RestPresenter : IActionResultPresenter
    {
        private CreateUserResponse _response;
        private string _error = "No response recorded";
        public RestPresenter()
        {
            _response = new CreateUserResponse();
        }

        public void Success(CreateUserResponse response)
        {
            _response = response;
        }

        public void Error(string error)
        {
            _error = error;
        }

        public IActionResult Render()
        {
            if (_response.Id != Guid.Empty)
                return new OkObjectResult(_response);
            return new BadRequestObjectResult(_error);
        }
    }
}
