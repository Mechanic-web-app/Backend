using AutoMapper;
using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.ChatRoom;
using MechanicWebAppAPI.Core.Dtos.Message;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Linq;
using Xunit;

namespace Core.Tests.RepositoryTests
{
    public class ChatRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IChat _chatRepository;
        private readonly IMapper _mapper;

        public ChatRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            _chatRepository = new ChatRepository(_contextBuilder.Context, _mapper);
        }

        [Theory]
        [InlineData("Example", "Example", "Example")]
        public async void SendMessageTest(string context, string lastname, string name)
        {
            var chatguid = _contextBuilder.Context.ChatRooms.FirstOrDefault(i => i.ChatRoom_id != Guid.Empty)?.ChatRoom_id ?? Guid.Empty;
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;
            var request = new SendMessageRequest()
            {

                Room_id = chatguid,
                MessageContext = context,
                MessageReceiver = Guid.NewGuid(),
                MessageSender = guid,
                UserLastname = lastname,
                UserName = name,
            };
            var result = await _chatRepository.Create(request).ConfigureAwait(false);
            Assert.IsType<MessageDto>(result);

        }
    }

}
