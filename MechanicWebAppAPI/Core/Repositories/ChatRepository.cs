using AutoMapper;
using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos.Message;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class ChatRepository : BaseRepository,IChat
    {
        private readonly IChat _chatRepository;
        public ChatRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public async Task<MessageDto> Create(SendMessageRequest message)
        {
            var messageDto = _mapper.Map<SendMessageRequest, Message>(message);
            messageDto.Message_id = Guid.NewGuid();
            messageDto.MessageTime = DateTime.Now;
            _context.Messages.Add(messageDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Message, MessageDto>(messageDto);
        }
        public async Task<IEnumerable<MessageDto>> GetMessagesByRoomId(Guid Room_id)
        {
            return await _context.Messages.Where(r => r.Room_id == Room_id).Select(message => _mapper.Map<Message,MessageDto>(message)).ToListAsync();
        }
    }
}
