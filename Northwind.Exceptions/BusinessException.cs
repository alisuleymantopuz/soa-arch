using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Exceptions
{
    public class BusinessException : SystemException
    {
        private BusinessExceptionCodes BusinessExceptionCode { get; set; }

        public BusinessException(BusinessExceptionCodes code)
        {
            this.BusinessExceptionCode = code;
        }
        public override string Message
        {
            get
            {
                return string.Format("{0} - {1}", (int)this.BusinessExceptionCode,
                                     this.BusinessExceptionCode.ToString());
            }
        }
    }
}
