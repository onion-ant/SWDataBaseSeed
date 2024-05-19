using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.DTOs.ApiDTOs.StreamingAvailability
{
    public class StreamingAvailabilityShowsResult
    {
        public List<Show> shows {  get; set; }
        public bool hasMore { get; set; }
        public string nextCursor { get; set; }
    }
}
