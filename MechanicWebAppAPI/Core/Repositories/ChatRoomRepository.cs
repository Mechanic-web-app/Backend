using AutoMapper;
using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos.ChatRoom;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Data.Database;
using MechanicWebAppAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class ChatRoomRepository : BaseRepository, IChatRoom
    {
        public ChatRoomRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<ChatRoomDto> Create(CreateChatRoomRequest request)
        {
            var chatRoomDto = _mapper.Map<CreateChatRoomRequest, ChatRoom>(request);
            _context.ChatRooms.Add(chatRoomDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ChatRoom, ChatRoomDto>(chatRoomDto);
        }
        public async Task<IEnumerable<ChatRoomDto>> Get()
        {
            return await _context.ChatRooms.Select(chatRoom => _mapper.Map<ChatRoom, ChatRoomDto>(chatRoom)).ToListAsync();
        }
        public async Task<ChatRoom> Get(Guid Room_id)
        {
            return await _context.ChatRooms.FindAsync(Room_id);
        }
        public async Task<bool> Delete(Guid Room_id)
        {
            var chatRoomToDelete = await _context.ChatRooms.FindAsync(Room_id);
            _context.ChatRooms.Remove(chatRoomToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
