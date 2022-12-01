using Microsoft.AspNetCore.Mvc;

namespace RepairShopStudio.Areas.Admin.Controlles
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
