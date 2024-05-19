using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StartDatabaseSeed.DTOs.ApiDTOs.StreamingAvailability;
using StartDatabaseSeed.DTOs.Mapping;
using StartDatabaseSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace StartDatabaseSeed.Services
{
    public class StreamingAvailabilityApi
    {
        public HttpClient _client { get; set; }
        public string ValidKey { get; set; }
        public IConfiguration _config { get; set; }

        public StreamingAvailabilityApi(IConfiguration config, HttpClient client)
        {
            _config = config;
            _client = client;

            var Keys = config.GetSection("StreamingAvailabilityKeys").Get<string[]>();
            if (Keys == null)
            {
                throw new Exception("Keys cannot be null");
            }
            foreach (var Key in Keys)
            {
                ValidKey = Key;
                var request = RequestBuilderShow();

                var response = _client.Send(request);
                if(response.IsSuccessStatusCode)
                {
                    break;
                }
                ValidKey = null;
            }
            if(ValidKey == null)
            {
                throw new Exception("No valid keys found");
            }
        }

        public async Task GetItems(ItemCatalog item)
        {
            string? nextCursor = _config["nextCursor"] != null ? _config["nextCursor"] : null;

            bool hasMore = true;
            StreamingAvailabilityShowsResult result = null;
            try
            {
                do
                {
                    var request = RequestBuilderShow(nextCursor);

                    var response = await _client.SendAsync(request);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Fail to fetch");
                    }

                    var body = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<StreamingAvailabilityShowsResult>(body);
                    hasMore = result.hasMore;
                    nextCursor = result.nextCursor;
                } while (hasMore);
                foreach(var show in result.shows)
                {
                    item = show.ToItem();
                }
            }
            catch (Exception)
            {

            }
        }
        public async Task<List<Streaming>> GetStreamings()
        {
            var request = RequestBuilderStreaming();

            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Fail to fetch");
            }
            var body = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<StreamingAvailabilityCountryResult>(body);
            var streamingList = new List<Streaming>();
            foreach (var streaming in result.services)
            {
                streamingList.Add(streaming.ToStreaming());
            }
            return streamingList;
        }
        private HttpRequestMessage RequestBuilderShow(string? nextCursor = null)
        {
            if (nextCursor == null)
            {
                var requestCursor = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/shows/search/filters?country=br&series_granularity=show&order_by=original_title&output_language=en&order_direction=asc&genres_relation=and"),
                    Headers =
                {
                    { "X-RapidAPI-Key", $"{ValidKey}" },
                    { "X-RapidAPI-Host", "streaming-availability.p.rapidapi.com" },
                },
                };

                return requestCursor;
            }
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://streaming-availability.p.rapidapi.com/shows/search/filters?country=br&cursor={nextCursor}&series_granularity=show&order_by=original_title&output_language=en&order_direction=asc&genres_relation=and"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{ValidKey}" },
                    { "X-RapidAPI-Host", "streaming-availability.p.rapidapi.com" },
                },
            };

            return request;
        }
        private HttpRequestMessage RequestBuilderStreaming()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/countries/br?output_language=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{ValidKey}" },
                    { "X-RapidAPI-Host", "streaming-availability.p.rapidapi.com" },
                },
            };

            return request;
        }
    }
}
