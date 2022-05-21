using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Data.Models
{
    public class Message
    {
        [Key]
        public Guid Message_id { get; set; }
        public Guid Room_id { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
        [Required]
        public Guid MessageSender { get; set; }
        [Required]
        public Guid MessageReceiver { get; set; }
        public virtual User User { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserLastname { get; set; }
        [Required]
        public string MessageContext { get; set; }
        [Required]
        public DateTime MessageTime { get; set; }

    }
}
