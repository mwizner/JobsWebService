using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.API.Core.Models
{
    //May be needed to handle additional components of price (duty, special taxes, etc...)
    public struct AdditionaPriceComponents
    {
        public double Tax { get; set; }
        public double Margin { get; set; }

        public double GetSumOfAdditionalPriceComponents()
        {
            return Tax + Margin;
        }
    }
}
