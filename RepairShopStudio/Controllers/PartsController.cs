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

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await partService.PartDetailsById(id);

            return RedirectToAction(nameof(Edit), new { id = id });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var part = await partService.GetPartById(id);

            //var vehicleComponentId = await partService.GetVehicleComponentId(id);
            //var VehicleComponents = await partService.GetVehicleComponentsAsync();

            var model = new PartViewModel()
            {
                Name = part.Name,
                Description = part.Description,
                Manufacturer = part.Manufacturer,
                ImageUrl = part.ImageUrl,
                OriginalMpn = part.OriginalMpn,
                PriceBuy = part.PriceBuy,
                PriceSell = part.PriceSell
                //VehicleComponentId = vehicleComponentId,
                //VehicleComponents = VehicleComponents,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(string id, PartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            partService.Edit(id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
    }
}
