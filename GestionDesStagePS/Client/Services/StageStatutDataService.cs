using GestionDesStagePS.Client.Interfaces;
using GestionDesStagePS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionDesStagePS.Client.Services
{
    public class StageStatutDataService: IStageStatutDataService
    {
         private readonly HttpClient _httpClient;

        public StageStatutDataService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<Stage> AddStage(Stage stage)
        {
            var donneesJson =
                new StringContent(JsonSerializer.Serialize(stage), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/stage", donneesJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Stage>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<IEnumerable<StageStatut>> GetAllStageStatuts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<StageStatut>>
                (await _httpClient.GetStreamAsync($"api/stagestatut"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
    }

