using AutoMapper;
using JobsWebService.API.Core.Models;
using JobsWebService.API.Core.Services.Contracts;
using JobsWebService.Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JobsWebService.API.Controllers
{
    [ApiController]
    [Route("jobs")]
    public class JobsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobQuotationCalculator _jobQuotationCalculator;

        //Both Automapper, and calcuation service are added by DI
        public JobsController(IMapper mapper, IJobQuotationCalculator jobQuotationCalculator)
        {
            _mapper = mapper;
            _jobQuotationCalculator = jobQuotationCalculator;
        }

        [HttpPost]
        //Used "POST" method to accept json from body
        //Didn't use async/await as all code is synchronous
        public  ActionResult<JobQuotationOutputDTO> GetQuotation([FromBody] JobQuotationInputDTO jobQuotationInputDTO)
        {
            //Simple check, but can be extended for additional needs
            if(jobQuotationInputDTO == null || jobQuotationInputDTO.PrintItems.Count == 0)
            {
                return BadRequest();
            }

            var inputQuotation = _mapper.Map<JobQuotation>(jobQuotationInputDTO);
            var result = _jobQuotationCalculator.CalculateJobQuotation(inputQuotation);
            var resultDTO = _mapper.Map<JobQuotationOutputDTO>(result);

            return Ok(resultDTO);
        }
    }
}
