using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.Core.Models.DTOs
{
    public class JobQuotationInputDTO
    {
        public bool IsExtraMargin { get; set; }
        public List<PrintItemInputDTO> PrintItems { get; set; }
    }
}
