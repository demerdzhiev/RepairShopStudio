using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.CustomerModels;
using RepairShopStudio.Core.Models.Vehicle;
using RepairShopStudio.Infrastructure.Data;
using static RepairShopStudio.Common.Constants.RoleConstants;

namespace RepairShopStudio.Controllers
{
    [Authorize]
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

        /// <summary>
        /// Get all customers from the Data-Base
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet]
        [Authorize(ServiceAdviser)]
        public async Task<IActionResult> All()
        {
            var model = await customerService.GetAllAsync();

            return View(model);
        }

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        [Authorize(ServiceAdviser)]
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

        /// <summary>
        /// Adding non-corpoarte custommer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>New non-corporate customer in Data-Base</returns>
        [HttpPost]
        [Authorize(ServiceAdviser)]
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

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        [Authorize(ServiceAdviser)]
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

        /// <summary>
        /// Adding corpoarte custommer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>New corporate customer in Data-Base</returns>
        [HttpPost]
        [Authorize(ServiceAdviser)]
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
