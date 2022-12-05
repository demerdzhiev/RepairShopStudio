using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.CustomerModels;
using RepairShopStudio.Core.Models.Vehicle;
using RepairShopStudio.Infrastructure.Data;

namespace RepairShopStudio.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ApplicationDbContext context;

        public CustomersController(
            ICustomerService _customerService,
            ApplicationDbContext _context)
        {
            customerService = _customerService;
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await customerService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddRegular()
        {
            var customerModel = new CustomerAddViewModel()
            {
                Vehicle = new VehicleAddViewModel()
                {
                    EngineTypes = context.EngineTypes.ToList()
                }
            };

            return View(customerModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegular(CustomerAddViewModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                customerModel.Vehicle.EngineTypes = context.EngineTypes.ToList();
                return View(customerModel);
            }

            try
            {
                await customerService.AddRegularCutomerAsync(customerModel);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(customerModel);
            }
        }

        [HttpGet]
        public IActionResult AddCorporate()
        {
            var customerModel = new CustomerAddViewModel()
            {
                Vehicle = new VehicleAddViewModel()
                {
                    EngineTypes = context.EngineTypes.ToList()
                }
            };

            return View(customerModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCorporate(CustomerAddViewModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                customerModel.Vehicle.EngineTypes = context.EngineTypes.ToList();
                return View(customerModel);
            }

            try
            {
                await customerService.AddCorporateCutomerAsync(customerModel);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(customerModel);
            }
        }
    }
}
