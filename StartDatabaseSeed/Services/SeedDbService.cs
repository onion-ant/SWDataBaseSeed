using StartDatabaseSeed.Data;
using StartDatabaseSeed.Models;
using StartDatabaseSeed.Services.ApiServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Services
{
    public class SeedDbService
    {
        private readonly AppDbContext _context;
        private readonly StreamingAvailabilityApi _streamingAvailabilityService;
        private readonly TmdbApi _tmdbApiService;
        public SeedDbService(StreamingAvailabilityApi streamingAvailabilityApi, AppDbContext context, TmdbApi tmdbApiService)
        {
            _streamingAvailabilityService = streamingAvailabilityApi;
            _context = context;
            _tmdbApiService = tmdbApiService;
        }
        public async Task SeedStreamings()
        {
            if (_context.Streamings.Any())
            {
                return;
            }
            var streamings = await _streamingAvailabilityService.GetStreamings();
            await _context.Streamings.AddRangeAsync(streamings);
            await _context.SaveChangesAsync();
        }
        public async Task SeedGenres()
        {
            if (_context.Genres.Any())
            {
                return;
            }
            var genres = await _streamingAvailabilityService.GetGenres();
            await _context.Genres.AddRangeAsync(genres);
            await _context.SaveChangesAsync();
        }
        public async Task SeedItems()
        {
            var ItemsLists = _streamingAvailabilityService.GetItems();
            await foreach(var items in ItemsLists)
            {
                await AddRangeItems(items);
            }
        }
        private async Task AddRangeItems(List<ItemCatalog> items)
        {
            foreach (var itemSource in items)
            {
                ItemCatalog item = new ItemCatalog()
                {
                    TmdbId = itemSource.TmdbId,
                    OriginalTitle = itemSource.OriginalTitle,
                    Rating = itemSource.Rating,
                    Type = itemSource.Type,
                    Genres = new List<Genre>(),
                };

                foreach (var genreId in itemSource.Genres)
                {
                    var genre = await _context.Genres.FindAsync(genreId.Id);
                    if (genre != null)
                    {
                        item.Genres.Add(genre);
                    }
                }

                if (_context.ItemsCatalog.FirstOrDefault(Item => Item.TmdbId == item.TmdbId) == null)
                {
                    await _tmdbApiService.GetTitle(item);
                    _context.ItemsCatalog.Add(item);
                    _context.SaveChanges();
                }
                if (itemSource.Streaming != null)
                {
                    await LinkStreamingsItems(itemSource);
                }
            }
        }
        private async Task LinkStreamingsItems(ItemCatalog itemSource)
        {
            foreach (var streaming in itemSource.Streaming)
            {
                if (_context.ItemsCatalog_Streamings.FirstOrDefault(ItemStreaming => ItemStreaming.ItemCatalogTmdbId == streaming.ItemCatalogTmdbId &&
                ItemStreaming.StreamingId == streaming.StreamingId) == null)
                {
                    _context.ItemsCatalog_Streamings.Add(streaming);
                    _context.SaveChanges();
                }
            }
        }
    }
}
