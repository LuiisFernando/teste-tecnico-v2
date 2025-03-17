using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Domain.Models;
using Thunders.TechTest.Infrastructure.Context;
using Thunders.TechTest.Infrastructure.Interfaces;

namespace Thunders.TechTest.Infrastructure.Repositories
{
    public class TollRepository(ThundersTechTestContext context) : ITollRepository
    {
        private readonly ThundersTechTestContext _context = context;

        public async Task AddTollLogsAsync(TollLog log)
        {
            await _context.TollLogs.AddAsync(log);
        }

        public async Task<List<TollLog>> GetAllTollLogsAsync()
        {
            return await _context.TollLogs.ToListAsync();
        }

        public async Task<List<HourlyCityReport>> GetHourlyCityReportAsync()
        {
            var reports = await _context.TollLogs
                .GroupBy(u => new
                {
                    u.City,
                    Hour = new DateTime(u.LogDateTime.Year, u.LogDateTime.Month, u.LogDateTime.Day, u.LogDateTime.Hour, 0, 0)
                })
                .Select(g => new HourlyCityReport
                {
                    City = g.Key.City,
                    Hour = g.Key.Hour,
                    TotalAmount = g.Sum(u => u.AmountPaid)
                }).ToListAsync();

            return reports;
        }

        public async Task<List<TopTollPlazasReport>> GetTopTollPlazasReportAsync(int topN)
        {
            var now = DateTime.UtcNow;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);

            var reports = await _context.TollLogs
                .Where(u => u.LogDateTime >= firstDayOfMonth)
                .GroupBy(u => u.TollPlaza)
                .Select(g => new TopTollPlazasReport
                {
                    Month = now.Month,
                    TollPlaza = g.Key,
                    TotalAmount = g.Sum(u => u.AmountPaid)
                })
                .OrderByDescending(r => r.TotalAmount)
                .Take(topN)
                .ToListAsync();

            return reports;
        }

        public async Task<List<TollLogCountReport>> GetTollLogCountReportAsync(string tollPlaza)
        {
            var reports = await _context.TollLogs
                .Where(u => u.TollPlaza == tollPlaza)
                .GroupBy(u => u.VehicleType)
                .Select(g => new TollLogCountReport
                {
                    TollPlaza = tollPlaza,
                    VehicleType = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            return reports;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
