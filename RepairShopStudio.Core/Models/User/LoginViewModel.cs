using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.User;

namespace RepairShopStudio.Core.Models.User
{
    [Comment(LoginViewModelMain)]
    public class LoginViewModel
    {
        [Required]
        [Comment(LoginViewModelUserName)]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Comment(LoginViewModelPassword)]
        public string Password { get; set; } = null!;

        [UIHint("hidden")]
        [Comment(LoginViewModelReturnUrl)]
        public string? ReturnUrl { get; set; }
    }
}
