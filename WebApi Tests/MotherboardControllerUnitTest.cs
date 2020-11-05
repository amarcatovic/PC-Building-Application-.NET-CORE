using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PC_Building_Application.Controllers;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;
using Xunit;

namespace WebApi_Tests
{
    public class MotherboardControllerUnitTest
    {
        private readonly Mock<IMotherboardRepo> _mockMotherboardRepo;
        private readonly Mock<HttpRequest> _mockRequest;
        private MotherboardsController _controller;

        public MotherboardControllerUnitTest()
        {
            _mockMotherboardRepo = new Mock<IMotherboardRepo>();
            _mockRequest = new Mock<HttpRequest>();
        }

        [Fact]
        public async Task GetAllMotheboards_Returns_Ok()
        {
            // Arange
            _mockMotherboardRepo.Setup(m => m.GetAllMotherboards())
                .ReturnsAsync(() => new List<MotherboardReadDto>());
            _mockRequest.Setup(m => m.Scheme).Returns("https");
            _mockRequest.Setup(m => m.Host).Returns(new HostString("pcbuilder.io"));
            _mockRequest.Setup(m => m.Path).Returns(new PathString("/unit-test"));
            
            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(m => m.Request).Returns(_mockRequest.Object);

            var context = new ControllerContext
            {
                HttpContext = mockContext.Object
            };

            _controller = new MotherboardsController(_mockMotherboardRepo.Object);

            // Act
            var result = (OkObjectResult) await _controller.GetMotherboards();
            var actual = (HttpStatusCode) result.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }

        [Fact]
        public async Task GetMotherboardById_Returns_Ok()
        {
            // Arange
            _mockMotherboardRepo.Setup(m => m.GetMotherboardById(It.IsAny<int>()))
                .ReturnsAsync(() => new MotherboardReadDto());
            _mockRequest.Setup(m => m.Scheme).Returns("https");
            _mockRequest.Setup(m => m.Host).Returns(new HostString("pcbuilder.io"));
            _mockRequest.Setup(m => m.Path).Returns(new PathString("/unit-test"));
            
            _controller = new MotherboardsController(_mockMotherboardRepo.Object);
            
            // Act
            var response = (OkObjectResult) await _controller.GetMotherboardById(It.IsAny<int>());
            var actual = (HttpStatusCode) response.StatusCode;
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);

        }

        [Fact]
        public async Task CreateMotherboard_Returns_BadRequest_ModelState()
        {
            // Arange
            _controller = new MotherboardsController(_mockMotherboardRepo.Object);
            _controller.ModelState.SetModelValue("unit-test", null, "error");
            
            // Act
            var result = (BadRequestResult) await _controller.AddMotherboard(null);
            var actual = (HttpStatusCode) result.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }
        
        [Fact]
        public async Task GetMotherboardById_Returns_NotFound()
        {
            // Arange
            _mockMotherboardRepo.Setup(m => m.GetMotherboardById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            _controller = new MotherboardsController(_mockMotherboardRepo.Object);
            
            // Act
            var result = (NotFoundObjectResult) await _controller.GetMotherboardById(It.IsAny<int>());
            var actual = (HttpStatusCode) result.StatusCode;
            
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, actual);
        }
    }
}