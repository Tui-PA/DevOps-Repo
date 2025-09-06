namespace devops_project.Models;

public class Meteorologia
{
    public string? DtHrLeitura { get; set; }
    public int? PressaoAtm { get; set; }
    public float? TemperaturaExt { get; set; }
    public float? UmidadeExt { get; set; }
    public int? DirecaoVento { get; set; }
    public float? VelocidadeVento { get; set; }
    public float? Precipitacao { get; set; }
}

public enum MeteorologiaPeriod
{
    Weekly,
    Monthly
}