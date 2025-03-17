using Moq;
using Thunders.TechTest.Application.Services;
using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Infrastructure.Interfaces;

namespace Thunders.TechTest.Tests.Application.Services
{
    public class TollServiceTests
    {
        private readonly Mock<ITollRepository> _repositoryMock;
        private readonly TollService _service;

        public TollServiceTests()
        {
            _repositoryMock = new Mock<ITollRepository>();
            _service = new TollService(_repositoryMock.Object);
        }

        [Fact]
        public async Task ProcessTollUsageAsync_CallsRepositoryMethods()
        {
            var log = new TollLog
            {
                TollPlaza = "praça 1",
                LogDateTime = DateTime.UtcNow
            };

            await _service.ProcessTollUsageAsync(log);

            _repositoryMock.Verify(r => r.AddTollLogsAsync(log), Times.Once);
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task ProcessTollUsageAsync_ThrowsException_WhenAddTollUsageFails()
        {
            var usage = new TollLog
            {
                TollPlaza = "Plaza1",
                LogDateTime = DateTime.UtcNow
            };

            var exception = new Exception("Test exception");
            _repositoryMock.Setup(r => r.AddTollLogsAsync(usage)).ThrowsAsync(exception);

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.ProcessTollUsageAsync(usage));
            Assert.Equal(exception, ex);

            _repositoryMock.Verify(r => r.AddTollLogsAsync(usage), Times.Once);
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
        }
    }
}
