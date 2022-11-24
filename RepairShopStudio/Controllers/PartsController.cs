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

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            //if ((await houseService.HasAgentWithId(id, User.Id())) == false)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            var part = await partService.PartDetailsById(id);
            var vehicleCpmponentId = await partService.GetVehicleComponentId(id);

            var model = new PartViewModel()
            {
                Id = id,
                Name = part.Name,
                VehicleComponentId = vehicleCpmponentId,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                PriceSell = part.PriceSell,
                Manufacturer = part.Manufacturer,
                OriginalMpn = part.OriginalMpn,
                Stock = part.Stock,
                VehicleCopmonents = await partService.AllVehicleComponents()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PartViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await partService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Component does not exist");
                model.VehicleCopmonents = await partService.AllVehicleComponents();

                return View(model);
            }

            if ((await partService.VehicleComponentExists(model.VehicleComponentId)) == false)
            {
                ModelState.AddModelError(nameof(model.VehicleComponentId), "Component does not exist");
                model.VehicleCopmonents = await partService.AllVehicleComponents();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.VehicleCopmonents = await partService.AllVehicleComponents();

                return View(model);
            }

            await partService.Edit(model.Id, model);

            //return RedirectToAction(nameof(Details), new { model.Id });
            return RedirectToAction("All", "Parts");
        }
    }
}
