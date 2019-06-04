using Microsoft.AspNetCore.Mvc;
using PeopleCoreAngularWebApplication.Controllers;
using PeopleCoreAngularWebApplication.Models;
using PeopleCoreAngularWebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PeopleCoreAngularWebApplication.Test
{
    public class UnitTest1
    {
        PeopleController _controller;
        IPeopleRepository _peopleRepository;

        public UnitTest1()
        {
            _peopleRepository = new PeopleRepositoryFake();
            _controller = new PeopleController(_peopleRepository);
        }

        [Fact]
        public async void Task_Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        //TODO: Sort out
        //[Fact]
        //public async void Task_Get_WhenCalled_ReturnsAllPeople()
        //{
        //    // Act
        //    var okResult = await Task.Run(() => _controller.Get().Result);

        //    // Assert
        //    Assert.IsType<List<Person>>(okResult.Value);
        //}

        [Fact]
        public async void Task_GetById_WhenCalled_WithUnknownGuidPassed_ReturnsNotFoundResult()
        {
            Guid id = new Guid();

            //Act  
            var result = await _controller.GetById(id);

            //Assert  
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
