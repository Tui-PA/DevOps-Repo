using devops_project.Controllers;
using devops_project.Helpers;
using devops_project.Models;
using devops_project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace devops_project_test;

public class MeteorologiaControllerTests
{
    private readonly Mock<ILogger<rmpgService>> _mockLogger;
    private readonly Mock<ILogger<MeteorologiaController>> _loggerController;
    private readonly rmpgService _rmpgService;
    private readonly MeteorologiaController _meteorologiaController;
    private readonly PeriodHelper _periodHelper;

    public MeteorologiaControllerTests()
    {
        _mockLogger = new Mock<ILogger<rmpgService>>();
        _loggerController = new Mock<ILogger<MeteorologiaController>>();
        _periodHelper = new PeriodHelper();
        _rmpgService = new rmpgService(_mockLogger.Object, _periodHelper);
        _meteorologiaController = new MeteorologiaController(_loggerController.Object, _rmpgService);
    }

    [Fact]
    public async Task GetMaregrafosAsync_ReturnsOkResult_WithListOfNames()
    {
        // Act
        OkObjectResult? result = await _meteorologiaController.GetMaregrafosAsync() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<List<Maregrafos>>(result.Value);
    }

    [Fact]
    public async Task GetLastDayMetereologyAsync_ReturnsOkResult_WithListOfScans()
    {
        // Arrange
        string maregrafo = "EMARC";

        // Act
        OkObjectResult? result = await _meteorologiaController.GetLastDayMetereologyAsync(maregrafo) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<List<Meteorologia>>(result.Value);
        Assert.NotEmpty((List<Meteorologia>)result.Value);
    }

    [Fact]
    public async Task GetLastDayMetereologyAsync_ReturnsNotFound()
    {
        // Arrange
        string maregrafo = "testMaregrafo";

        // Act
        var result = await _meteorologiaController.GetLastDayMetereologyAsync(maregrafo) as NotFoundObjectResult;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetLastWeekMetereologyAsync_ReturnsOkResult_WithListOfScans()
    {
        // Arrange
        string maregrafo = "EMARC";

        // Act
        OkObjectResult? result = await _meteorologiaController.GetLastWeekMetereologyAsync(maregrafo) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<List<Meteorologia>>(result.Value);
        Assert.NotEmpty((List<Meteorologia>)result.Value);
    }

    [Fact]
    public async Task GetLastWeekMetereologyAsync_ReturnsNotFound()
    {
        // Arrange
        string maregrafo = "testMaregrafo";

        // Act
        var result = await _meteorologiaController.GetLastWeekMetereologyAsync(maregrafo) as NotFoundObjectResult;

        // Assert
        Assert.Null(result);
    }
}
