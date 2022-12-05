using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.OperatingCard;

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
        public async Task<IActionResult> Add()
        {
            var model = new OperatingCardAddViewModel()
            {
                Customers = await operatingCardService.GetCustomersAsync(),
                Vehicles = await operatingCardService.GetVehicles(),
                ApplicationUsers = await operatingCardService.GetMechanicsAsync(),
                Parts = BindPartsList(),
                Services = BindServicesList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OperatingCardAddViewModel model)
        {
            if (model.PartIds != null)
            {
                List<SelectListItem> selectedParts
                    = model.Parts.Where(p => model.PartIds.Contains(int.Parse(p.Value))).ToList();

                foreach (var part in selectedParts)
                {
                    part.Selected = true;
                }
            }

            if (model.ServiceIds != null)
            {
                List<SelectListItem> selectedServices
                    = model.Services.Where(s => model.ServiceIds.Contains(int.Parse(s.Value))).ToList();

                foreach (var service in selectedServices)
                {
                    service.Selected = true;
                }
            }


            if (!ModelState.IsValid)
            {
                model.Customers = (ICollection<Infrastructure.Data.Models.Customer>)operatingCardService.GetCustomersAsync();
                model.Vehicles = (ICollection<Infrastructure.Data.Models.Vehicle>)operatingCardService.GetVehicles();
                model.ApplicationUsers = (ICollection<Infrastructure.Data.Models.User.ApplicationUser>)operatingCardService.GetMechanicsAsync();
                model.Parts = BindPartsList();
                model.Services = BindServicesList();

                return View(model);
            }

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

        public List<SelectListItem> BindPartsList()
        {
            var selectParts = new List<SelectListItem>();
            var parts = operatingCardService.GetParts();
            foreach (var part in parts)
            {
                selectParts.Add(new SelectListItem
                {
                    Text = part.Name,
                    Value = part.Id.ToString()
                });
            }
            return selectParts;
        }

        public List<SelectListItem> BindServicesList()
        {
            var selectServices = new List<SelectListItem>();
            var services = operatingCardService.GetShopServices();
            foreach (var service in services)
            {
                selectServices.Add(new SelectListItem
                {
                    Text = service.Name,
                    Value = service.Id.ToString()
                });
            }
            return selectServices;
        }
    }
}
