using devops_project.Interfaces;
using devops_project.Models;
using devops_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace devops_project.Controllers;

[ApiController]
[Route("api")]
public class MeteorologiaController : ControllerBase
{

    private readonly ILogger<MeteorologiaController> _logger;
    private readonly IrmpgService _rmpgService;

    public MeteorologiaController(ILogger<MeteorologiaController> logger, rmpgService rmpgService)
    {
        _logger = logger;
        _rmpgService = rmpgService;
    }

    [HttpGet("maregrafos")]
    public async Task<IActionResult> GetMaregrafosAsync()
    {
        _logger.LogInformation($"Starting request: maregrafos");
        var response = await _rmpgService.GetMaregrafosAsync();
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpGet("metereologia/semana/{maregrafo}")]
    public async Task<IActionResult> GetLastWeekMetereologyAsync(string maregrafo)
    {
        _logger.LogInformation($"Starting request: LastWeekMetereology: {maregrafo}");
        var response = await _rmpgService.GetMeteorologiaAsync(maregrafo, MeteorologiaPeriod.Weekly);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpGet("metereologia/mes/{maregrafo}")]
    public async Task<IActionResult> GetLastMonthMetereologyAsync(string maregrafo)
    {
        _logger.LogInformation($"Starting request: LastMonthMetereology: {maregrafo}");
        var response = await _rmpgService.GetMeteorologiaAsync(maregrafo, MeteorologiaPeriod.Monthly);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
