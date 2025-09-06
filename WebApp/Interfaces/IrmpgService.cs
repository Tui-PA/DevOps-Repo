using devops_project.Models;

namespace devops_project.Interfaces;

public interface IrmpgService
{
    public Task<List<Maregrafos>?> GetMaregrafosAsync();
    public Task<List<Meteorologia>?> GetMeteorologiaAsync(string maregrafo, MeteorologiaPeriod period);
}
