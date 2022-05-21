using MechanicWebAppAPI.Core.Dtos.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Api.Hubs
{
    public interface IChatClient
    {
        Task RefreshMessagesList(IEnumerable<MessageDto> messages);
        Task ConnectMessage(string connMessage, MessageType messageType = MessageType.Undefined);
        Task RefreshCallersList(IEnumerable<string> callers);
        Task PushNotification(string userName, string userLastname);
    }
}
