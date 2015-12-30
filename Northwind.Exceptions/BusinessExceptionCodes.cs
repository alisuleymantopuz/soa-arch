using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Exceptions
{
    public enum BusinessExceptionCodes
    {
        Success = 0000,
        ValueCanNotNull = 1001,
        CategoryIdCanNotNull = 2001,
        CategoryCanNotNull = 2002,

    }
}
