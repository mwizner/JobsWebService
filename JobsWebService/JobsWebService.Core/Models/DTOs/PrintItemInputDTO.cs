using JobsWebService.API.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.Core.Models.DTOs
{
    public class PrintItemInputDTO : PrintItemDTO
    {
        public double Price { get; set; }
        public bool IsTaxExemption { get; set; }
    }
}
