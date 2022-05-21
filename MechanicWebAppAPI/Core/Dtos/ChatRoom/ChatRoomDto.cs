using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Dtos.ChatRoom
{
    public class ChatRoomDto
    {
        public Guid Room_id { get; set; }
        public string RoomName { get; set; }
    }
}
