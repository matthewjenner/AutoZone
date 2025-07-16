using AutoMapper;
using AutoZone.Domain.Dtos;
using AutoZone.Domain.Models;
using System;
using System.Linq;

namespace AutoZone.Api.MappingProfiles;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        // Vehicle to VehicleDto
        CreateMap<Vehicle, VehicleDto>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => 
                string.IsNullOrEmpty(src.Features) ? new string[0] : src.Features.Split(new[] { ',' }, StringSplitOptions.None)))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => 
                string.IsNullOrEmpty(src.ImageUrls) ? new string[0] : src.ImageUrls.Split(new[] { ';' }, StringSplitOptions.None)));

        // CreateVehicleDto to Vehicle
        CreateMap<CreateVehicleDto, Vehicle>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => 
                (src.Features != null && src.Features.Length > 0) ? string.Join(",", src.Features) : string.Empty))
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => 
                (src.Images != null && src.Images.Length > 0) ? string.Join(";", src.Images) : string.Empty));

        // UpdateVehicleDto to Vehicle
        CreateMap<UpdateVehicleDto, Vehicle>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => 
                (src.Features != null && src.Features.Length > 0) ? string.Join(",", src.Features) : string.Empty))
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => 
                (src.Images != null && src.Images.Length > 0) ? string.Join(";", src.Images) : string.Empty));
    }
} 