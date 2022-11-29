using RepairShopStudio.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace RepairShopStudio.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IPartModel part)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetName(part.Name.Replace(" ", "-")));
            sb.Append("-");
            sb.Append(part.Manufacturer);
            sb.Append("-");
            sb.Append(part.OriginalMpn);

            return sb.ToString();
        }

        private static string GetName(string name)
        {
            string result = string
                .Join("-", name.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(3));

            return Regex.Replace(name, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
