using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos.ChatRoom;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IChatRoom
    {
        Task<ChatRoomDto> Create(CreateChatRoomRequest request);
        Task<IEnumerable<ChatRoomDto>> Get();
        Task<ChatRoom> Get(Guid ChatRoom_id);
        Task<bool> Delete(Guid ChatRoom_id);
    }
}
