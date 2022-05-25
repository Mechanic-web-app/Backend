using MechanicWebAppAPI.Common.Requests.CarRequests;
using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Common.Requests.OpinionRequests;
using MechanicWebAppAPI.Common.Requests.RepairRequests;
using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Core.Dtos.ChatRoom;
using MechanicWebAppAPI.Core.Dtos.Message;
using MechanicWebAppAPI.Core.Dtos.Opinion;
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
            CreateMap<Data.Models.Opinion, OpinionDto>();
            CreateMap<Data.Models.Message, MessageDto>();
            CreateMap<Data.Models.ChatRoom, ChatRoomDto>();
            CreateMap<CarAddRequest, Data.Models.Car>();
            CreateMap<RepairAddRequest, Data.Models.Repair>();
            CreateMap<OpinionAddRequest, Data.Models.Opinion>();
            CreateMap<SendMessageRequest, Data.Models.Message>();
            CreateMap<CreateChatRoomRequest, Data.Models.ChatRoom>();
            CreateMap<string, Guid>();
        }
    }
}