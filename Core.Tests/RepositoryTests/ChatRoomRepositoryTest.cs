using AutoMapper;
using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.ChatRoom;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Linq;
using Xunit;

namespace Core.Tests.RepositoryTests
{
    public class ChatRoomRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IChatRoom _chatroomRepository;
        private readonly IMapper _mapper;

        public ChatRoomRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            _chatroomRepository = new ChatRoomRepository(_contextBuilder.Context, _mapper);
        }

        [Theory]
        [InlineData("Example")]
        public async void CreateChatRoomTest(string roomname)
        {

            var request = new CreateChatRoomRequest()
            {
                Room_id = Guid.NewGuid(),
                RoomName = roomname
            };
            var result = await _chatroomRepository.Create(request).ConfigureAwait(false);
            Assert.IsType<ChatRoomDto>(result);
        }

        [Theory]
        [InlineData(true)]
        public async void DeleteChatRoomTest(bool expected)
        {
            var guid = _contextBuilder.Context.ChatRooms.FirstOrDefault(i => i.Room_id != Guid.Empty)?.Room_id ?? Guid.Empty;
            var result = await _chatroomRepository.Delete(guid).ConfigureAwait(false);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async void GetChatRoomTest()
        {
            var guid = _contextBuilder.Context.ChatRooms.FirstOrDefault(i => i.Room_id != Guid.Empty)?.Room_id ?? Guid.Empty;
            var result = await _chatroomRepository.Get(guid).ConfigureAwait(false);
            Assert.IsType<ChatRoom>(result);
        }

    }

}
