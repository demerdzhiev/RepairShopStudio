using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Customer;
using RepairShopStudio.Core.Models.Part;

namespace RepairShopStudio.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await customerService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CustomerAddViewModel()
            {
                //EngineTypes = (IEnumerable<Core.Models.EngineType.EngineTypeViewModel>)customerService.AllEngineTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await customerService.AddCutomerAsync(model);

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
