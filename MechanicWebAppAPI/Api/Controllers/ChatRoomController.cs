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
        [HttpGet("{Room_id}")]
        public async Task<ActionResult<ChatRoom>> Get(Guid Room_id)
        {
            return await _chatRoomRepository.Get(Room_id);
        }

        [HttpDelete("{Room_id}")]
        public async Task<bool> Delete(Guid Room_id)
        {
            var chatRoomToDelete = await _chatRoomRepository.Get(Room_id);
            if (chatRoomToDelete == null)
                return false;

            await _chatRoomRepository.Delete(chatRoomToDelete.Room_id);
            return true;
        }

    }
}