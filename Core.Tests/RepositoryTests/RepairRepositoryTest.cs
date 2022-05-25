using AutoMapper;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Common.Requests.RepairRequests;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.Repair;
using MechanicWebAppAPI.Core.Interfaces;
using MechanicWebAppAPI.Core.Repositories;
using MechanicWebAppAPI.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests.RepositoryTests
{
    public class RepairRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IRepairs _repairsRepository;
        private readonly IMapper _mapper;

        public RepairRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            _repairsRepository = new RepairRepository(_contextBuilder.Context, _mapper);
        }

        [Theory]
        [InlineData("example", 100)]
        public async void AddRepairTest(string description, int cost)
        {
            var guid = _contextBuilder.Context.Cars.FirstOrDefault(i => i.Car_id != Guid.Empty)?.Car_id ?? Guid.Empty;

            var request = new RepairAddRequest()
            {
                Repair_description = description,
                Repair_cost = cost,
                Repair_date = DateTime.Today.ToString(),
                Repaired_car_id = guid,
            };

            var result = await _repairsRepository.Create(request).ConfigureAwait(false);

            Assert.IsType<RepairDto>(result);
        }

        [Fact]
        public async void GetRepairTest()
        {
            var guid = _contextBuilder.Context.Repairs.FirstOrDefault(i => i.Repair_id != Guid.Empty)?.Repair_id ?? Guid.Empty;
            var result = await _repairsRepository.Get(guid).ConfigureAwait(false);
            Assert.IsType<Repair>(result);
        }
    }

}
