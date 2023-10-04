using CleanArchitecture.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitechure.Web.Presenters
{
    public interface IActionResultPresenter : IPresenter
    {
        IActionResult Render();
    }
}
