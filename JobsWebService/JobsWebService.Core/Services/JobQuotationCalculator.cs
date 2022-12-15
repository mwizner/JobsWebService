using JobsWebService.API.Core.Models;
using JobsWebService.API.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.API.Core.Services
{
    public class JobQuotationCalculator : IJobQuotationCalculator
    {
        public double SalesTax { get; private set; } = 0.07;
        public double Margin { get; private set; } = 0.11;
        public double ExtraMargin { get; private set; } = 0.16;

        public JobQuotation CalculateJobQuotation(JobQuotation input)
        {
            var margin = input.IsExtraMargin ? ExtraMargin : Margin;

            //Creating copy of all items to not mutate input object
            var newItems = input.PrintItems.Select(i => new PrintItem {
                Description = i.Description,
                IsTaxExemption = i.IsTaxExemption,
                Price = Math.Round(i.Price, 2) }).ToList();


            foreach (var item in newItems)
            {
                var taxValue = item.IsTaxExemption ? 0 : item.Price * SalesTax;
                var marginValue = item.Price * margin;
                item.AdditionaPriceComponents = new AdditionaPriceComponents { Tax = Math.Round(taxValue, 2), Margin = Math.Round(marginValue, 2) };
            }

            return new JobQuotation { IsExtraMargin = input.IsExtraMargin, PrintItems = newItems };
        }

        public void SetCustomSalesTaxes(double newTax)
        {
            SalesTax = newTax;
        }

        public void SetCustomMargin(double newMargin)
        {
            Margin = newMargin;
        }

        public void SetCustomExtraMargin(double newExtraMargin)
        {
            ExtraMargin = newExtraMargin;
        }

    }
}
