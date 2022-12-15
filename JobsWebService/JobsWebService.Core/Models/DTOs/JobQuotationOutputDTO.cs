using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.Core.Models.DTOs
{
    public class JobQuotationOutputDTO
    {
        public List<PrintItemOutputDTO> PrintItems { get; set; }
        public double Total { get; set; }
    }
}
