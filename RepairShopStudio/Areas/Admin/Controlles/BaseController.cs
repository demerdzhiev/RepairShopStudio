using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RepairShopStudio.Common.Constants.AdminConstants;

namespace RepairShopStudio.Areas.Admin.Controlles
{
    [Area(AdminAreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRolleName)]

    public class BaseController : Controller
    {
       
    }
}
