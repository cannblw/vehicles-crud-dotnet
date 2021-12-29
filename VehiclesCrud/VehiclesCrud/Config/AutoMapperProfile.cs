using AutoMapper;
using VehiclesCrud.Details;
using VehiclesCrud.Models;

namespace VehiclesCrud.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleDetails>();
        }
    }
}