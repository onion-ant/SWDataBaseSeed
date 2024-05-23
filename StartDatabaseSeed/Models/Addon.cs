using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartDatabaseSeed.Models
{
    public class Addon
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? HomePage { get; set; }
        [ForeignKey(nameof(Streaming))]
        public string? StreamingId { get; set; }
    }
}