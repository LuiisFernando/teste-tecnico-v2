using Microsoft.AspNetCore.Mvc;
using Moq;
using Thunders.TechTest.ApiService.Controllers;
using Thunders.TechTest.Application.Interfaces;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.Tests.ApiService
{
    public class TollControllerTests
    {
        private readonly Mock<IReportService> _reportServiceMock;
        private readonly Mock<ITollService> _tollService;
        private readonly TollController _controller;

        public TollControllerTests()
        {
            _reportServiceMock = new Mock<IReportService>();
            _tollService = new Mock<ITollService>();
            _controller = new TollController(_tollService.Object, _reportServiceMock.Object);
        }

        [Fact]
        public async Task LogTollUsage_ReturnsBadRequest_WhenUsageIsNull()
        {
            var result = await _controller.LogToll(null);
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Dados inválidos.", badRequest.Value);
        }

        [Fact]
        public async Task TollLog_ReturnsOk_WhenMessageSuccessfully()
        {
            var log = new TollLog 
            { 
                TollPlaza = "praça 1",
                LogDateTime = DateTime.UtcNow,
                AmountPaid = 20m 
            };
           
            var result = await _controller.LogToll(log);
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal("Log pedágio salvo com sucesso.", okResult.Value);
        }
    }
}
