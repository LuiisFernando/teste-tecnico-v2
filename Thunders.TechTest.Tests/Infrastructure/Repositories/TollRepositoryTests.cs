using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Domain.Enums;
using Thunders.TechTest.Infrastructure.Context;
using Thunders.TechTest.Infrastructure.Repositories;

namespace Thunders.TechTest.Tests.Infrastructure.Repositories
{
    public class TestTollDataContext(DbContextOptions<ThundersTechTestContext> options) : ThundersTechTestContext(options)
    {
    }
    public class TollRepositoryTests
    {
        private static ThundersTechTestContext InMemoryContext
        {
            get
            {
                var options = new DbContextOptionsBuilder<ThundersTechTestContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                return new ThundersTechTestContext(options);
            }
        }

        [Fact]
        public async Task AddTollLogAsync_ShouldAdd()
        {
            // Arrange
            using var context = InMemoryContext;
            var repository = new TollRepository(context);
            var log = new TollLog
            {
                LogDateTime = DateTime.UtcNow,
                TollPlaza = "praça 1",
                City = "Jacareí",
                State = "SP",
                AmountPaid = 7.7m,
                VehicleType = VehicleType.Motorcycle
            };

            // Act
            await repository.AddTollLogsAsync(log);
            await repository.SaveChangesAsync();

            var logs = await repository.GetAllTollLogsAsync();

            // Assert
            Assert.Single(logs);
            Assert.Equal("praça 1", logs.First().TollPlaza);
        }
    }
}
