using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;

namespace RepairShopStudio.Controllers
{
    public class PartController : Controller
    {
        private readonly IPartService partService;

        public PartController(IPartService _partService)
        {
            partService = _partService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await partService.GetAllAsync();

            return View(model);
        }
    }
}
