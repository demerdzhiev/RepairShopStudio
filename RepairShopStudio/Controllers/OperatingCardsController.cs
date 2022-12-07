using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.OperatingCard;
using System.Security.Claims;

namespace RepairShopStudio.Controllers
{
    public class OperatingCardsController : Controller
    {
        private readonly IOperatingCardService operatingCardService;

        public OperatingCardsController(IOperatingCardService _operatingCardService)
        {
            operatingCardService = _operatingCardService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await operatingCardService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int customerId)
        {
            var model = new OperatingCardAddViewModel()
            {
                CustomerId = customerId,
                CustomerName = await operatingCardService.GetCustomerNameById(customerId),
                Vehicles = await operatingCardService.GetCustomerVehicles(customerId),
                ApplicationUsers = await operatingCardService.GetMechanicsAsync(),
                Parts = await operatingCardService.GetPartsAsync(),
                ShopServices = await operatingCardService.GetShopServicesAsync(),
                IsActive = true
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OperatingCardAddViewModel model, int customerId)
        {

            //if (!ModelState.IsValid)
            //{
            //    model.CustomerId = customerId;
            //    model.CustomerName = await operatingCardService.GetCustomerNameById(customerId);
            //    model.Vehicles = await operatingCardService.GetCustomerVehicles(customerId);
            //    model.ApplicationUsers = await operatingCardService.GetMechanicsAsync();
            //    model.Parts = await operatingCardService.GetPartsAsync();
            //    model.ShopServices = await operatingCardService.GetShopServicesAsync();
            //    model.IsActive = true;

            //    return View(model);
            //}

            try
            {
                await operatingCardService.AddOperatingCardAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Finish(int cardId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await operatingCardService.MarkRepairAsFinishedAsync(cardId, userId);
            }
            catch(Exception)
            {
                throw new ArgumentException("Something went wrong...");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> AllFinished()
        {
            var model = await operatingCardService.GetAllFinishedAsync();

            return View(model);
        }
    }
}
