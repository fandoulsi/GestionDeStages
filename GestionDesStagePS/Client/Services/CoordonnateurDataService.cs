using GestionDesStagePS.Client.Interfaces;
using GestionDesStagePS.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Services
{
    public class CoordonnateurDataService : ICoordonnateurDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EntrepriseDataService> _logger;

        public CoordonnateurDataService(HttpClient httpClient, ILogger<EntrepriseDataService> logger)
        {
            _httpClient = httpClient;
            this._logger = logger;
        }

        public async Task<Coordonnateur> GetCoordonnateurById(string Id)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<Coordonnateur>
                    (await _httpClient.GetStreamAsync($"api/coordonnateur/{Id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention de données d'un enregistrement {ex}");
            }
            return null;
        }

        public async Task<Coordonnateur> AddCoordonnateur(Coordonnateur coordonnateur)
        {
            var donneesJson =
                new StringContent(JsonSerializer.Serialize(coordonnateur), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/coordonnateur", donneesJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Coordonnateur>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateCoordonnateur(Coordonnateur coordonnateur)
        {
            var stageJson =
                new StringContent(JsonSerializer.Serialize(coordonnateur), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/coordonnateur", stageJson);
        }
    }
}
