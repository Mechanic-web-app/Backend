using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Dtos.Message
{
    public class MessageDto
    {
        public Guid Message_id { get; set; }
        public Guid Room_id { get; set; }
        public Guid MessageSender { get; set; }
        public Guid MessageReceiver { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string MessageContext { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
