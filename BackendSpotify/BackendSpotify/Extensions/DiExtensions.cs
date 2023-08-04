using BackendSpotify.Domain.Implementations;
using BackendSpotify.Domain.Interfaces;

namespace BackendSpotify.Extensions
{
    public static class DiExtensions
    {
        public static void RegisterServices(this IServiceCollection services, WebApplicationBuilder? builder)
        {
            services.AddScoped<IGetMePlaylistsService, GetMePlaylistsService>();
            services.AddScoped<IGetFeaturedPlaylistsService, GetFeaturedPlaylistsService>();
            services.AddScoped<IGetPlaylistByIdService, GetPlaylistByIdService>();
            services.AddScoped<IGetSearchService, GetSearchService>();
        }
    }
}
