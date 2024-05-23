using AutoMapper;
using StartDatabaseSeed.DTOs.ApiDTOs.StreamingAvailability;
using StartDatabaseSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.DTOs.Mapping
{
    public static class EntityExtentions
    {
        public static ItemCatalog? ToItem(this Show show)
        {
            return new ItemCatalog()
            {
                TmdbId = show.tmdbId,
                OriginalTitle = show.originalTitle,
                Type = (int)show.showType,
                Genres = show.genres.Select(g => g.ToGenre()).ToList(),
                Rating = show.rating,
                Streaming = show.streamingOptions.br.Select(so => so.ToItemCatalogStreaming(show.tmdbId)).ToList(),
            };
        }
        public static Genre ToGenre(this GenreApi genreApi)
        {
            return new Genre()
            {
                Id = genreApi.id,
                Name = genreApi.name,
            };
        }
        public static ItemCatalog_Streaming ToItemCatalogStreaming(this StreamingOption sOption, string tmdbId)
        {
            return new ItemCatalog_Streaming()
            {
                TmdbId = tmdbId,
                StreamingId = sOption.service.id,
                expiresSoon = sOption.expiresSoon,
                Link = sOption.link,
                Price = sOption.price?.amount,
                Type = (int)sOption.type
            };
        }
        public static Streaming ToStreaming(this StreamingService service)
        {
            return new Streaming()
            {
                Id = service.id,
                HomePage = service.homepage,
                Name = service.name,
                addons = service.addons.Select(addon => addon.ToAddon()).ToList()
            };
        }
        public static Addon ToAddon(this AddonStreaming addonStreaming)
        {
            return new Addon()
            {
                Id = addonStreaming.id,
                HomePage = addonStreaming.homePage,
                Name = addonStreaming.name
            };
        }
    }
}
