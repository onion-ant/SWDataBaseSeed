﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Models
{
    [PrimaryKey(nameof(ItemCatalogTmdbId),nameof(StreamingId))]
    public class ItemCatalog_Streaming
    {
        [ForeignKey(nameof(ItemCatalog))]
        public string? ItemCatalogTmdbId { get; set; }
        [ForeignKey(nameof(Streaming))]
        public string? StreamingId { get; set; }
        public bool? expiresSoon { get; set; }
        public double? Price { get; set; }
        public int? Type { get; set; }
        public string? Link {  get; set; }
    }
}
