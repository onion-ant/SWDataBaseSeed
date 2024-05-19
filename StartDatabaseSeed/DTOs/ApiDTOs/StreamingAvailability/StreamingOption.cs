using StartDatabaseSeed.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.DTOs.ApiDTOs.StreamingAvailability
{
    public class StreamingOption
    {
        public StreamingService service { get; set; }
        public string quality { get; set; }
        public StreamingType type {  get; set; }
        public string link { get; set; }
        public bool expiresSoon { get; set; }
        public Price price { get; set; }

    }
}
