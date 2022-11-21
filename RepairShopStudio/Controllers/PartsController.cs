using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;

namespace RepairShopStudio.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService partService;

        public PartsController(IPartService _partService)
        {
            partService = _partService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await partService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPartViewModel()
            {
                VehicleComponents = await partService.GetVehicleComponentsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await partService.AddPartAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }
    }
}
