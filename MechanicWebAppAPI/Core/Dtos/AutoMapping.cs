using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Core.Dtos.Repair;
using MechanicWebAppAPI.Core.Dtos.User;

namespace MechanicWebAppAPI.Core.Dtos
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<Data.Models.User, UserDto>();
            CreateMap<Data.Models.Repair, RepairDto>();
            CreateMap<Data.Models.Car, CarDto>();
        }
    }
}