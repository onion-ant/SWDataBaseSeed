using StartDatabaseSeed.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.DTOs.ApiDTOs.StreamingAvailability
{
    public class Show
    {
        public ItemType showType {  get; set; }
        public string tmdbId { get; set; }
        public string originalTitle { get; set;}
        public string overview { get; set;}
        public int releaseYear { get; set;}
        public List<GenreApi> genres { get; set;}
        public Country streamingOptions { get; set;}
        public int rating { get; set;}
    }
}
