using MechanicWebAppAPI.Common.Requests.CarRequests;
using MechanicWebAppAPI.Common.Requests.OpinionRequests;
using MechanicWebAppAPI.Common.Requests.RepairRequests;
using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Core.Dtos.Repair;
using MechanicWebAppAPI.Core.Dtos.User;
using System;

namespace MechanicWebAppAPI.Core.Dtos
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<Data.Models.User, UserDto>();
            CreateMap<Data.Models.Repair, RepairDto>();
            CreateMap<Data.Models.Car, CarDto>();
            CreateMap<CarAddRequest, Data.Models.Car>();
            CreateMap<RepairAddRequest, Data.Models.Repair>();
            CreateMap<OpinionAddRequest, Data.Models.Repair>();
            CreateMap<string, Guid>();
        }
    }
}