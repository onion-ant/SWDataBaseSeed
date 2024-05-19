using StartDatabaseSeed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Services
{
    public class SeedDbService
    {
        public readonly AppDbContext _context;
        public readonly StreamingAvailabilityApi _streamingAvailabilityService;
        public SeedDbService(StreamingAvailabilityApi streamingAvailabilityApi, AppDbContext context)
        {
            _streamingAvailabilityService = streamingAvailabilityApi;
            _context = context;
        }
    }
}
