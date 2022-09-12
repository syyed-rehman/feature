using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace SongLyrics.Presentation.Controllers
{
    [Route("api/artists/{artistId}/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SongsController(IServiceManager service)
        {
            _service = service;
        }       

        [HttpGet]
        public async Task<IActionResult> GetSongs(int artistId)
        {
            var songs = await _service.SongService.GetSongsAsync(artistId);

            return Ok(songs);
        }
    }
}
