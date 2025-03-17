using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.Application.Interfaces
{
    public interface ITollService
    {
        Task ProcessTollLogAsync(TollLog usage);
    }
}
