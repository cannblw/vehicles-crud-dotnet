using AutoMapper;
using VehiclesTest.Details;
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