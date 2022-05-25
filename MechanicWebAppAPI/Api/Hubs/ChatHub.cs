using MechanicWebAppAPI.Common.Helpers;
using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Helpers;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Models;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MechanicWebAppAPI.Api.Hubs
{
    public partial class ChatHub : Hub<IChatClient>
    {
        private readonly IChat _chatRepository;
        private readonly IChatRoom _chatRoomRepository;

        public ChatHub(IChat ChatRepository, IChatRoom ChatRoomRepository)
        {
            _chatRepository = ChatRepository;
            _chatRoomRepository = ChatRoomRepository;
        }
        public async Task ConnectToChatRoom(CreateChatRoomRequest request, ConnectToChatRoomRequest connRequest)
        {
            
            if (request != null)
            {
                var roomId = request.ChatRoom_id.ToString();
                ConnectionObserver.ConnectionStates[Context.ConnectionId] = new CallerEntry
                {
                    Group = roomId,
                    User_id = connRequest.CallerId,
                    CallerName = connRequest.CallerName,
                    CallerLastname = connRequest.CallerLastname
                };
                if (connRequest.CallerId == roomId)
                {
                    var checkRoom = await _chatRoomRepository.Get(request.ChatRoom_id);
                    if (checkRoom == null)
                    {

                        await _chatRoomRepository.Create(request);
                    }
                }

                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
                
                var messages = await _chatRepository.GetMessagesByRoomId(request.ChatRoom_id);
                await Clients.Caller.RefreshMessagesList(messages);

                await Clients.Caller.ConnectMessage("Chat joined successfully", MessageType.Success);

            }
            else
            {
                await Clients.Caller.ConnectMessage($"Chat not found", MessageType.Error);
            }
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string connectionId = Context.ConnectionId;
            string groupName = ConnectionObserver.GetCurrentGroupName(connectionId);
            ConnectionObserver.ConnectionStates.Remove(Context.ConnectionId);
            if (groupName != null)
            {
                var playersList = ConnectionObserver.GetCallersList(groupName);
                await Clients.Group(groupName).RefreshCallersList(playersList);
            }
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(SendMessageRequest message)
        {
            var roomId = message.Room_id.ToString();

            if (roomId != null)
            {
                await _chatRepository.Create(message);
                var messages = await _chatRepository.GetMessagesByRoomId(message.Room_id);
                await Clients.Group(roomId).RefreshMessagesList(messages);
                await Clients.All.PushNotification(message.UserName, message.UserLastname);
            }
            else
            {
                await Clients.Caller.ConnectMessage("Failed to send message. Current room not found.", MessageType.Error);
            }
        }
    }
}
