using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StartDatabaseSeed.DTOs.ApiDTOs.StreamingAvailability;
using StartDatabaseSeed.DTOs.ApiDTOs.Tmdb;
using StartDatabaseSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Services.ApiServices
{
    public class TmdbApi
    {
        public HttpClient _client { get; set; }
        public string ValidKey { get; set; }
        public IConfiguration _config { get; set; }

        public TmdbApi(IConfiguration config, HttpClient client)
        {
            _config = config;
            _client = client;

            var Keys = config.GetSection("TmdbApiKeys").Get<string[]>();
            if (Keys == null)
            {
                throw new Exception("Keys cannot be null");
            }
            foreach (var Key in Keys)
            {
                ValidKey = Key;
                var request = RequestBuilder("movie/438631");

                var response = _client.Send(request);
                if (response.IsSuccessStatusCode)
                {
                    break;
                }
                ValidKey = null;
            }
            if (ValidKey == null)
            {
                throw new Exception("No valid keys found");
            }
        }
        public async Task GetTitle(ItemCatalog item)
        {
            var request = RequestBuilder(item.TmdbId);

            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var body = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TmdbResult>(body);
            item.Title = result.title == null ? result.name : result.title;
        }
        private HttpRequestMessage RequestBuilder(string tmdbId)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/{tmdbId}?language=pt-BR"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", $"Bearer {ValidKey}" },
                },
            };
        }
    }
}
