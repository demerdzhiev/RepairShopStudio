using Microsoft.AspNetCore.Mvc.Rendering;
using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.Core.Models.User
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; } = null!;

        public IList<SelectListItem> Roles { get; set; } = null!;
    }
}
