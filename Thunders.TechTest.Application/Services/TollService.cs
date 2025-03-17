using Thunders.TechTest.Application.Interfaces;
using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Infrastructure.Interfaces;

namespace Thunders.TechTest.Application.Services
{
    public class TollService(ITollRepository repository) : ITollService
    {
        private readonly ITollRepository _repository = repository;

        public async Task ProcessTollLogAsync(TollLog log)
        {
            try
            {
                await _repository.AddTollLogsAsync(log);
                await _repository.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
