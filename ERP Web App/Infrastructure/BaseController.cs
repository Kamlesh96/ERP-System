using Microsoft.AspNetCore.Mvc;

namespace ERP_Web_App.Infrastructure
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController : Controller
    {
    }
}
