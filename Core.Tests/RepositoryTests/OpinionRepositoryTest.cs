using AutoMapper;
using MechanicWebAppAPI.Common.Requests.OpinionRequests;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.Opinion;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Linq;
using Xunit;

namespace Core.Tests.RepositoryTests
{
    public class OpinionRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IOpinions _opinionsRepository;
        private readonly IMapper _mapper;

        public OpinionRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            _opinionsRepository = new OpinionRepository(_contextBuilder.Context, _mapper);
        }

        [Theory]
        [InlineData("example", 5 ,"example", "example")]
        public async void AddOpinionTest(string description, int rate, string lastname, string name)
        {
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;

            var request = new OpinionAddRequest()
            {
                Opinion_user_id = guid,
                Opinion_description = description,
                Opinion_rate = rate,
                Opinion_user_lastname = lastname,
                Opinion_user_name = name,
            };

            var result = await _opinionsRepository.Create(request).ConfigureAwait(false);

            Assert.IsType<OpinionDto>(result);
        }
        [Theory]
        [InlineData(true)]
        public async void DeleteOpinionTest(bool expected)
        {
            var guid = _contextBuilder.Context.Opinions.FirstOrDefault(i => i.Opinion_id != Guid.Empty)?.Opinion_id ?? Guid.Empty;
            var result = await _opinionsRepository.Delete(guid).ConfigureAwait(false);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async void GetOpinionTest()
        {
            var guid = _contextBuilder.Context.Opinions.FirstOrDefault(i => i.Opinion_id != Guid.Empty)?.Opinion_id ?? Guid.Empty;
            var result = await _opinionsRepository.Get(guid).ConfigureAwait(false);
            Assert.IsType<Opinion>(result);
        }

    }

}
