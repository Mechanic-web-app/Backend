using AutoMapper;
using MechanicWebAppAPI.Common.Requests.UserRequests;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Linq;
using Xunit;

namespace Core.Tests.RepositoryTests
{
    public class UserRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IUsers _usersRepository;
        private readonly IMapper _mapper;

        public UserRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            _usersRepository = new UserRepository(_contextBuilder.Context, _mapper);
        }

        [Theory]
        [InlineData("test2@example.com", "test", "test3", "123456789",true)]
        public async void ProfileUpdateTest(string email, string name, string lastname, string phone_number,bool expected)
        {
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;

            var request = new ProfileUpdateRequest()
            {
                Email = email,
                Name = name,
                Lastname = lastname,
                Phone_number = phone_number
            };
            var result = await _usersRepository.ProfileUpdate(guid, request).ConfigureAwait(false);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(true, true)]
        public async void ConfirmUserTest(bool confirm, bool expected)
        {
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;

            var request = new ConfirmUserRequest()
            {
                User_confirmed = confirm,
            };
            var result = await _usersRepository.Update(guid, request).ConfigureAwait(false);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(true)]
        public async void DeleteUserTest(bool expected)
        {
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;
            var result = await _usersRepository.Delete(guid).ConfigureAwait(false);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async void GetUserTest()
        {
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;
            var result = await _usersRepository.Get(guid).ConfigureAwait(false);
            Assert.IsType<User>(result);
        }

    }

}
