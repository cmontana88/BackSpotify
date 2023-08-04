using Microsoft.AspNetCore.Mvc;
using BackendSpotify.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendSpotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly IGetMePlaylistsService _getMePlaylistsService;
        private readonly IGetFeaturedPlaylistsService _getFeaturedPlaylistsService;
        private readonly IGetPlaylistByIdService _getPlaylistByIdService;
        private readonly IGetSearchService _getSearchService;

        public SpotifyController(IGetMePlaylistsService getMePlaylistsService, IGetFeaturedPlaylistsService getFeaturedPlaylistsService, IGetPlaylistByIdService getPlaylistByIdService, IGetSearchService getSearchService)
        {
            _getMePlaylistsService = getMePlaylistsService;
            _getFeaturedPlaylistsService = getFeaturedPlaylistsService;
            _getPlaylistByIdService = getPlaylistByIdService;
            _getSearchService = getSearchService;   
        }

        [HttpGet("me/playlists")]
        public async Task<IActionResult> GetMePlaylists()
        {
            // Intenta obtener el valor de la cabecera "Authorization"
            if (Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                // Aquí puedes procesar el valor de la cabecera "Authorization"
                // Por ejemplo, puedes extraer el token sin el prefijo "Bearer "
                var token = authorizationHeader.ToString().Substring("Bearer ".Length);

                var response = await _getMePlaylistsService.Execute(token);

                if (response.HasErrors)
                    return BadRequest(response.Errors);

                // Devuelve una respuesta con éxito
                return Ok(response.Result);
            }
            else
            {
                // Si no se encuentra la cabecera "Authorization", devuelve una respuesta de error
                return Unauthorized(new { message = "Cabecera Authorization no encontrada." });
            }
        }

        [HttpGet("featuredPlaylists")]
        public async Task<IActionResult> GetFeaturedPlaylists()
        {
            // Intenta obtener el valor de la cabecera "Authorization"
            if (Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                // Aquí puedes procesar el valor de la cabecera "Authorization"
                // Por ejemplo, puedes extraer el token sin el prefijo "Bearer "
                var token = authorizationHeader.ToString().Substring("Bearer ".Length);

                var response = await _getFeaturedPlaylistsService.Execute(token);

                if (response.HasErrors)
                    return BadRequest(response.Errors);

                // Devuelve una respuesta con éxito
                return Ok(response.Result);
            }
            else
            {
                // Si no se encuentra la cabecera "Authorization", devuelve una respuesta de error
                return Unauthorized(new { message = "Cabecera Authorization no encontrada." });
            }
        }

        [HttpGet("Playlist/{globalPlaylistId}")]
        public async Task<IActionResult> GetPlaylist(string globalPlaylistId)
        {
            // Intenta obtener el valor de la cabecera "Authorization"
            if (Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                // Aquí puedes procesar el valor de la cabecera "Authorization"
                // Por ejemplo, puedes extraer el token sin el prefijo "Bearer "
                var token = authorizationHeader.ToString().Substring("Bearer ".Length);

                var response = await _getPlaylistByIdService.Execute(token, globalPlaylistId);

                if (response.HasErrors)
                    return BadRequest(response.Errors);

                // Devuelve una respuesta con éxito
                return Ok(response.Result);
            }
            else
            {
                // Si no se encuentra la cabecera "Authorization", devuelve una respuesta de error
                return Unauthorized(new { message = "Cabecera Authorization no encontrada." });
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetSearch(string q, string type)
        {
            // Intenta obtener el valor de la cabecera "Authorization"
            if (Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                // Aquí puedes procesar el valor de la cabecera "Authorization"
                // Por ejemplo, puedes extraer el token sin el prefijo "Bearer "
                var token = authorizationHeader.ToString().Substring("Bearer ".Length);

                var response = await _getSearchService.Execute(token, q, type);

                if (response.HasErrors)
                    return BadRequest(response.Errors);

                // Devuelve una respuesta con éxito
                return Ok(response.Result);
            }
            else
            {
                // Si no se encuentra la cabecera "Authorization", devuelve una respuesta de error
                return Unauthorized(new { message = "Cabecera Authorization no encontrada." });
            }
        }
    }
}
