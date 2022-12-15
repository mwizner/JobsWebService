using AutoMapper;
using JobsWebService.API.Core.Models;
using JobsWebService.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsWebService.API.Core.Configurartions
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<JobQuotation, JobQuotationInputDTO>().ReverseMap();
            CreateMap<JobQuotation, JobQuotationOutputDTO>().ReverseMap();
            CreateMap<PrintItem, PrintItemOutputDTO>()
                .ForMember(dto => dto.PriceWithTax, ent => ent.MapFrom(p => p.Price + p.AdditionaPriceComponents.Tax));
            CreateMap<PrintItem, PrintItemInputDTO>().ReverseMap();
        }
    }
}
