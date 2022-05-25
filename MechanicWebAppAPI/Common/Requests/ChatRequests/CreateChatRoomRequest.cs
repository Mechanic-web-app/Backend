using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.ChatRequests
{
    public class CreateChatRoomRequest
    {
        [Required]
        public Guid ChatRoom_id { get; set; }
        [Required]
        public string RoomName { get; set; }
    }
}
