using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Services
{
    internal class StreamingAvailabilityApi
    {
        public HttpClient _client { get; set; }
        public string[] Keys { get; set; }
        public IConfiguration _config { get; set; }

        public StreamingAvailabilityApi(IConfiguration config,HttpClient client)
        {
            _config = config;
            _client = client;

            Keys = config.GetSection("StreamingAvailabilityKeys").Get<string[]>();
            if(Keys == null)
            {
                throw new Exception("Keys cannot be null");
            }
        }
    }
}
