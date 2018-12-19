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
          /*  CreateMap<HotelDTO, Hotel>()
                .ForMember(x => x.HotelRoomType, opt => opt.Ignore())
                .ForMember(x => x.Participant, opt => opt.Ignore())
                .ReverseMap();
                */
        }


    }
}
