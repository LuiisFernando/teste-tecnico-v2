using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Domain.Models;

namespace Thunders.TechTest.Infrastructure.Interfaces
{
    public interface ITollRepository
    {
        Task AddTollLogsAsync(TollLog usage);
        Task<List<TollLog>> GetAllTollLogsAsync();
        Task<List<HourlyCityReport>> GetHourlyCityReportAsync();
        Task<List<TopTollPlazasReport>> GetTopTollPlazasReportAsync(int topN);
        Task<List<TollLogCountReport>> GetTollLogCountReportAsync(string tollPlaza);
        Task SaveChangesAsync();
    }
}
