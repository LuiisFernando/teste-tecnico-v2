using Thunders.TechTest.Application.Interfaces;
using Thunders.TechTest.Domain.Models;
using Thunders.TechTest.Infrastructure.Interfaces;

namespace Thunders.TechTest.Application.Services
{
    public class ReportService(ITollRepository repository) : IReportService
    {
        private readonly ITollRepository _repository = repository;

        public async Task<List<HourlyCityReport>> GenerateHourlyCityReportAsync()
        {
            try
            {
                return await _repository.GetHourlyCityReportAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TopTollPlazasReport>> GenerateTopTollPlazasReportAsync(int topN)
        {
            try
            {
                return await _repository.GetTopTollPlazasReportAsync(topN);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TollLogCountReport>> GenerateTollLogCountReportAsync(string tollPlaza)
        {
            try
            {
                return await _repository.GetTollLogCountReportAsync(tollPlaza);
            }
            catch
            {
                throw;
            }
        }
    }
}
