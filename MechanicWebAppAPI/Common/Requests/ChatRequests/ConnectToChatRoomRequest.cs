using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Requests.ChatRequests
{
    public class ConnectToChatRoomRequest
    {
        public string CallerId { get; set; }
        public string CallerName { get; set; }
        public string CallerLastname { get; set; }
    }
}
