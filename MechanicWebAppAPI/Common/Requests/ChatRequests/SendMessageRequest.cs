using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.ChatRequests
{
    public class SendMessageRequest
    {
        [Required]
        public Guid Room_id { get; set; }
        [Required]
        public Guid MessageSender { get; set; }
        [Required]
        public Guid MessageReceiver { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserLastname { get; set; }
        [Required]
        public string MessageContext { get; set; }
    }
}
