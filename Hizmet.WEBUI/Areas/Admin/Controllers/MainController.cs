using Microsoft.AspNetCore.Mvc;

namespace Hizmet.WEBUI.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
