namespace devops_project.Models;

public class Meteorologia
{
    public string? DtHrLeitura { get; set; }
    public double? PressaoAtm { get; set; }
    public double? TemperaturaExt { get; set; }
    public double? UmidadeExt { get; set; }
    public int? DirecaoVento { get; set; }
    public double? VelocidadeVento { get; set; }
    public double? Precipitacao { get; set; }
}

public enum MeteorologiaPeriod
{
    Daily,
    Weekly
}