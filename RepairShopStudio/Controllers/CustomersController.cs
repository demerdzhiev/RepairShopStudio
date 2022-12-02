using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Services;

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
    }
}
