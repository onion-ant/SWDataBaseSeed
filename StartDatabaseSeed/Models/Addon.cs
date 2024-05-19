using System.ComponentModel.DataAnnotations;

namespace StartDatabaseSeed.Models
{
    public class Addon
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string HomePage { get; set; }
    }
}