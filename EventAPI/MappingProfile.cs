using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace EventAPI
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CompanyDTO, Company>()
                .ForMember(x => x.Participant, opt => opt.Ignore())
                .ForMember(x => x.MainOfficeCountry, opt => opt.Ignore())
                .ReverseMap();
                cfg.CreateMap<CountryDTO, Country>()
                .ForMember(x => x.Company, opt => opt.Ignore())
                .ForMember(x => x.ParticipantCitizenship, opt => opt.Ignore())
                .ForMember(x => x.ParticipantResidenceCountry, opt => opt.Ignore());
            });


        }


    }
}
