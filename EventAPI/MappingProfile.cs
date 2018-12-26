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
                    .ForMember(x => x.ParticipantResidenceCountry, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<EventsDTO, Events>()
                    .ForMember(x => x.Participant, opt => opt.Ignore())
                    .ForMember(x => x.Newsletter, opt => opt.Ignore())
                    .ForMember(x => x.EventProgElem, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<TypeDTO, Type>()
                    .ForMember(x => x.EventProgElem, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<HotelDTO, Hotel>()
                    .ForMember(x => x.HotelRoomType, opt => opt.Ignore())
                    .ForMember(x => x.Participant, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<HotelRoomTypeDTO, HotelRoomType>()
                    .ForMember(x => x.hotel, opt => opt.Ignore())
                    .ForMember(x => x.Participant, opt => opt.Ignore())
                    .ReverseMap();
            });


        }


    }
}
