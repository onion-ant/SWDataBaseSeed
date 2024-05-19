using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Models
{
    public class Streaming
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string HomePage { get; set; }
        public List<Addon> addons { get; set; }
    }
}
