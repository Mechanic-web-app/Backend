using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos.Message;
using MechanicWebAppAPI.Core.Interfaces;
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
    public class ChatController : ControllerBase
    {
        private readonly IChat _chatRepository;
        public ChatController(IChat ChatRepository)
        {
            _chatRepository = ChatRepository;
        }
        public async Task<ActionResult<MessageDto>> SendMessage([FromBody] SendMessageRequest message)
        {
            return await _chatRepository.Create(message);
        }

    }
}
