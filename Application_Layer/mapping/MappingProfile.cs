using Application_Layer.DTO;
using AutoMapper;
using Domain_layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.mapping
{
    // DENNA KLAS Mapping mellan Entity → DTO
    // AutoMapper mappar automatiskt data

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Product → ProductDto
            CreateMap<Product, ProductDto>()

                // 🔥 Hämtar Username från User
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(src => src.User.Username));
        }
    }
}
