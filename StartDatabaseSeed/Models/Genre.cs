﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Models
{
    public class Genre
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<ItemCatalog>? Items { get; set; }
    }
}
