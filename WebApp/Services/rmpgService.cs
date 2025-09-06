using devops_project.Helpers;
using devops_project.Interfaces;
using devops_project.Models;
using System.Text.Json;

namespace devops_project.Services
{
    public class rmpgService : IrmpgService
    {
        HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string baseUrlApi = "https://servicodados.ibge.gov.br/api/v1/rmpg";
        private IPeriodHelper _periodHelper;

        public rmpgService(ILogger<rmpgService> logger, IPeriodHelper periodHelper)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _periodHelper = periodHelper;
        }
        
        public async Task<List<Maregrafos>?> GetMaregrafosAsync()
        {
            string rmpgEndpointUrl = "/maregrafos";
            string uriString = string.Concat(baseUrlApi, rmpgEndpointUrl);
            _logger.LogInformation($"Starting request to RMPG API: {uriString}");
            var rmpgReponse = await _httpClient.GetAsync(uriString);
            
            if (rmpgReponse.IsSuccessStatusCode)
            {
                var content = await rmpgReponse.Content.ReadAsStringAsync();
                var maregrafos = JsonSerializer.Deserialize<List<Maregrafos>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _logger.LogInformation(content);
                return maregrafos;
            }

            return null;
        }
        
        public async Task<List<Meteorologia>?> GetMeteorologiaAsync(string maregrafo, MeteorologiaPeriod period)
        {
            string rmpgEndpointUrl = $"/meteorologia/{maregrafo}?momentoInicial={_periodHelper.GetInitialDate(period):yyyy-MM-dd-HH-mm}&momentoFinal={_periodHelper.GetFinalDate():yyyy-MM-dd-HH-mm}";
            string uriString = string.Concat(baseUrlApi, rmpgEndpointUrl);
            _logger.LogInformation($"Starting request to RMPG API: {uriString}");
            var rmpgReponse = await _httpClient.GetAsync(uriString);
            
            if (rmpgReponse.IsSuccessStatusCode)
            {
                var content = await rmpgReponse.Content.ReadAsStringAsync();
                var meteorologia = JsonSerializer.Deserialize<List<Meteorologia>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _logger.LogInformation(content);
                return meteorologia;
            }

            return null;
        }
    }
}
