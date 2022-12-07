using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Extensions;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;

namespace RepairShopStudio.Areas.Admin.Controlles
{
    public class PartsController : Controller
    {
        private readonly IPartService partService;
        private readonly ApplicationDbContext context;

        public PartsController(IPartService _partService,
            ApplicationDbContext _context)
        {
            partService = _partService;
            context = _context;
        }

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var part = await partService.PartDetailsById(id);
            var vehicleCompnentId = await partService.GetVehicleComponentId(id);

            var model = new PartViewModel()
            {
                Id = id,
                Name = part.Name,
                PriceBuy = part.PriceBuy,
                PriceSell = part.PriceSell,
                Description = part.Description,
                Manufacturer = part.Manufacturer,
                OriginalMpn = part.OriginalMpn,
                ImageUrl = part.ImageUrl,
                Stock = part.Stock,
                VehicleComponentId = vehicleCompnentId,
                VehicleComponents = await partService.AllVehicleComponents()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PartViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await partService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                model.VehicleComponents = await partService.AllVehicleComponents();
                return View(model);
            }

            if ((await partService.VehicleComponentExists(model.VehicleComponentId)) == false)
            {
                ModelState.AddModelError(nameof(model.VehicleComponentId), "Category does not exist");
                model.VehicleComponents = await partService.AllVehicleComponents();

                return View(model);
            }

            if (!ModelState.IsValid == false)
            {
                model.VehicleComponents = await partService.AllVehicleComponents();

                return View(model);
            }

            await partService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetPartInformation() });
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await partService.PartDetailsById(id);

            if (information != model.GetPartInformation())
            {
                TempData["ErrorMessage"] = "Don't touch my slug!";

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            TempData["SuccessDeletePartMessage"] = "Part was deleted sucessfully";
            await partService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
