using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Data.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid ChatRoom_id { get; set; }
        public string RoomName { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
