using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.ShopService;

namespace RepairShopStudio.Controllers
{
    public class ShopServicesController : Controller
    {
        private readonly IShopServiceService shopServiceService;

        public ShopServicesController(IShopServiceService _shopServiceService)
        {
            shopServiceService = _shopServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await shopServiceService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddShopServiceViewModel()
            {
                VehicleComponents = (IEnumerable<Infrastructure.Data.Models.VehicleComponent>)await shopServiceService.GetVehicleComponentsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddShopServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await shopServiceService.AddAsync(model);

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
