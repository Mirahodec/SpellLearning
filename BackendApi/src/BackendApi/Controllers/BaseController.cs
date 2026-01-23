using Domain. Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        public User User => (User)HttpContext.Items["User"];
    }
}