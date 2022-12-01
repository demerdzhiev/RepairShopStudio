using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Exceptions
{
    public class RepairShopException : ApplicationException
    {
        public RepairShopException()
        {

        }

        public RepairShopException(string errorMessage)
            :base(errorMessage)
        {
        }
    }
}
