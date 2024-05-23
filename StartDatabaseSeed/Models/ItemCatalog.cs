using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Models
{
    public class ItemCatalog
    {
        [Key]
        public string? TmdbId { get; set; }
        public string? Title { get; set; }
        public string? OriginalTitle { get; set; }
        public int? Rating { get; set; }
        public int? Type { get; set; }
        public List<ItemCatalog_Streaming>? Streaming { get; set; }
        public List<Genre>? Genres { get; set; }
    }
}
