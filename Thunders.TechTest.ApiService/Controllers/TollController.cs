using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.Application.Interfaces;
using Thunders.TechTest.Application.Services;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollController(ITollService tollService, IReportService reportService) : ControllerBase
    {
        private readonly ITollService _tollService = tollService;
        private readonly IReportService _reportService = reportService;

        [HttpPost("log")]
        public async Task<IActionResult> LogToll([FromBody] TollLog? log)
        {
            if (log == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _tollService.ProcessTollUsageAsync(log);
                return Ok("Log pedágio salvo com sucesso.");
            }
            catch
            {
                return BadRequest("Erro interno no servidor.");
            }
        }


        [HttpGet("reports/hourlyCity")]
        public async Task<IActionResult> GetHourlyCityReport()
        {
            try
            {
                var report = await _reportService.GenerateHourlyCityReportAsync();
                return Ok(report);
            }
            catch
            {
                return BadRequest("Erro interno no servidor.");
            }
        }

        [HttpGet("reports/topTollPlazas")]
        public async Task<IActionResult> GetTopTollPlazasReport([FromQuery] int topN = 5)
        {
            try
            {
                var report = await _reportService.GenerateTopTollPlazasReportAsync(topN);
                return Ok(report);
            }
            catch
            {
                return BadRequest("Erro interno no servidor.");
            }
        }

        [HttpGet("reports/tollLogCount")]
        public async Task<IActionResult> GetTollLogCountReport([FromQuery] string tollPlaza)
        {
            if (string.IsNullOrWhiteSpace(tollPlaza))
            {
                return BadRequest("O parâmetro 'tollPlaza' é obrigatório.");
            }

            try
            {
                var report = await _reportService.GenerateTollLogCountReportAsync(tollPlaza);
                return Ok(report);
            }
            catch
            {
                return BadRequest("Erro interno no servidor");
            }
        }
    }
}
