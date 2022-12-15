using JobsWebService.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.API.Core.Services.Contracts
{
    public interface IJobQuotationCalculator
    {
        JobQuotation CalculateJobQuotation(JobQuotation input);
    }
}
