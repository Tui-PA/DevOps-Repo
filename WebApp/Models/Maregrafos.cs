namespace devops_project.Models;
public class Maregrafos
{
    public string SiglaMaregrafo { get; set; }
    public string NomeMaregrafo { get; set; }
    public string Local { get; set; }
    public string SiglaUF { get; set; }
    public DateTime DataInicialOperacao { get; set; }
    public string UrlRelatorio { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public int? IdGLOSS { get; set; }
    public int? IdUHSLC { get; set; }
    public int? IdPSMSL { get; set; }
}