using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.API.Core.Models
{
    public class PrintItem
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsTaxExemption { get; set; }
        public double TotalPrice
        {
            get
            {
                var priceNotRounded = Price + AdditionaPriceComponents.GetSumOfAdditionalPriceComponents();
                return Math.Round(priceNotRounded, 2);
            }
        }
        public AdditionaPriceComponents AdditionaPriceComponents { get; set; }
    }
}
