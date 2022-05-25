using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos.ChatRoom;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoom _chatRoomRepository;
        public ChatRoomController(IChatRoom ChatRoomRepository)
        {
            _chatRoomRepository = ChatRoomRepository;
        }
        [HttpPost]
        public async Task<ActionResult<ChatRoomDto>> Create([FromBody]CreateChatRoomRequest request)
        {
            return await _chatRoomRepository.Create(request);
        }
        [HttpGet]
        public async Task<IEnumerable<ChatRoomDto>> GetChatRooms()
        {
            return await _chatRoomRepository.Get();
        }
        [HttpGet("{ChatRoom_id}")]
        public async Task<ActionResult<ChatRoom>> Get(Guid ChatRoom_id)
        {
            return await _chatRoomRepository.Get(ChatRoom_id);
        }

        [HttpDelete("{ChatRoom_id}")]
        public async Task<bool> Delete(Guid ChatRoom_id)
        {
            var chatRoomToDelete = await _chatRoomRepository.Get(ChatRoom_id);
            if (chatRoomToDelete == null)
                return false;

            await _chatRoomRepository.Delete(chatRoomToDelete.ChatRoom_id);
            return true;
        }

    }
}