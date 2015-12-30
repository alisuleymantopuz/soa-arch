using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Data
{
    [DataContract]
    public class CreateCategoryResponse
    {
        [DataMember]
        public int CategoryId { get; set; }
    }
}
