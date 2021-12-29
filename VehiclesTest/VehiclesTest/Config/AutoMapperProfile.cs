using AutoMapper;
using VehiclesTest.Dto;
using VehiclesTest.Models;

namespace VehiclesTest.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleDetails>();
        }
    }
}