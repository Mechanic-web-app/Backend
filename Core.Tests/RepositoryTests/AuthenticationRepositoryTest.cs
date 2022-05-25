using AutoMapper;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Common.Requests.Authentication;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.User;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests.RepositoryTests
{
    public class AuthenticationRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IAuthentication _authenticationRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHelper _jwtHelper;

        public AuthenticationRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            var mockJwt = new Mock<IJwtHelper>();
            mockJwt.Setup(_ => _.GenerateJwtToken(It.IsAny<UserDto>())).Returns(new JwtToken() { AccessToken = "Bearer XYZ" });
            mockJwt.Setup(_ => _.GetUserId()).Returns(_contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty);
            _jwtHelper = mockJwt.Object;
            _authenticationRepository = new AuthenticationRepository(_contextBuilder.Context, _mapper, _jwtHelper);
        }

        [Theory]
        [InlineData("example@example.com", "example")]
        public async void LoginTest(string email, string password)
        {
            var request = new LoginRequest()
            {
                Email = email,
                Password = password,
            };

            var result = await _authenticationRepository.Login(request).ConfigureAwait(false);

            Assert.IsType<JwtToken>(result);
        }

        [Theory]
        [InlineData("test2@example.com", "Test123.", "test", "test3","123456789")]
        public async void RegisterTest(string email, string password, string firstname, string lastname,string phone_number)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                Password = password,
                Name = firstname,
                Lastname = lastname,
                Phone_number = phone_number
            };

            var result = await _authenticationRepository.Register(request).ConfigureAwait(false);

            Assert.IsType<Guid>(result);
        }
    }
}

