using JobsWebService.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.API.Core.Models
{
    public class JobQuotation
    {
        public bool IsExtraMargin { get; set; }
        public List<PrintItem> PrintItems { get; set; }
        public double Total
        {
            get
            {
                var total = 0.0;

                foreach (var item in PrintItems)
                {
                    total += item.TotalPrice;
                }

                return Math.Round(total, 2);
            }
        }
    }
}
