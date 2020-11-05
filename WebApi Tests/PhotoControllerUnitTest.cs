using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PC_Building_Application.Controllers;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Dtos;
using PC_Building_Application.Data.Repositories.Interfaces;
using Xunit;

namespace WebApi_Tests
{
    public class PhotoControllerUnitTest
    {
        private readonly Mock<IPhotoRepo> _mockPhotoRepo;
        private readonly Mock<HttpRequest> _mockRequest;
        private PhotosController _controller;

        public PhotoControllerUnitTest()
        {
            _mockPhotoRepo = new Mock<IPhotoRepo>();
            _mockRequest = new Mock<HttpRequest>();
        }

        [Fact]
        public async Task GetAllPhotos_Returns_Ok()
        {
            // Arange
            _mockPhotoRepo.Setup(m => m.GetPhoto(It.IsAny<int>()))
                .ReturnsAsync(() => new PhotoReturnDto());
            _mockRequest.Setup(m => m.Scheme).Returns("https");
            _mockRequest.Setup(m => m.Host).Returns(new HostString("pcbuilder.io"));
            _mockRequest.Setup(m => m.Path).Returns(new PathString("/unit-test"));

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(p => p.Request).Returns(_mockRequest.Object);

            var context = new ControllerContext
            {
                HttpContext = mockContext.Object
            };

            _controller = new PhotosController(_mockPhotoRepo.Object);

            // Act
            var result = (OkObjectResult) await _controller.GetPhoto(It.IsAny<int>());
            var actual = (HttpStatusCode) result.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }
    }
}