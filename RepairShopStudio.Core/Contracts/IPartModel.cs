using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Contracts
{
    public interface IPartModel
    {
        public string Name { get; }

        public string Manufacturer { get; }

        public string OriginalMpn { get; }
    }
}
