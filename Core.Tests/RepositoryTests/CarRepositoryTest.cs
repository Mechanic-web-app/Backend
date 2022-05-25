using AutoMapper;
using MechanicWebAppAPI.Common.Jwt;
using MechanicWebAppAPI.Common.Requests.CarRequests;
using MechanicWebAppAPI.Core.Dtos;
using MechanicWebAppAPI.Core.Dtos.Car;
using MechanicWebAppAPI.Core.Dtos.User;
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
    public class CarRepositoryTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly ICars _carsRepository;
        private readonly IMapper _mapper;

        public CarRepositoryTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping())).CreateMapper();
            _contextBuilder = new ContextBuilder();
            _carsRepository = new CarRepository(_contextBuilder.Context, _mapper);
        }

        [Theory]
        [InlineData("example", "example", "example")]
        public async void AddCarTest(string brand, string model, string regNumber)
        {
            var guid = _contextBuilder.Context.Users.FirstOrDefault(i => i.User_id != Guid.Empty)?.User_id ?? Guid.Empty;

            var request = new CarAddRequest()
            {
                Car_brand = brand,
                Car_model = model,
                Car_reg_number = regNumber,
                Car_user_id = guid.ToString()
            };

            var result = await _carsRepository.Create(request).ConfigureAwait(false);

            Assert.IsType<CarDto>(result);
        }

        [Fact]
        public async void GetCarTest()
        {
            var guid = _contextBuilder.Context.Cars.FirstOrDefault(i => i.Car_id != Guid.Empty)?.Car_id ?? Guid.Empty;
            var result = await _carsRepository.Get(guid).ConfigureAwait(false);
            Assert.IsType<Car>(result);
        }
        [Theory]
        [InlineData(true)]
        public async void DeleteCarTest(bool expected)
        {
            var guid = _contextBuilder.Context.Cars.FirstOrDefault(i => i.Car_id != Guid.Empty)?.Car_id ?? Guid.Empty;
            var result = await _carsRepository.Delete(guid).ConfigureAwait(false);
            Assert.Equal(expected,result);
        }

    }

}