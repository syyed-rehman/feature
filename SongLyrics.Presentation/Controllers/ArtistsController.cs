using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace SongLyrics.Presentation.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController: ControllerBase
    {
        private readonly IServiceManager _service;

        public ArtistsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{name}", Name = "ArtistByName")]
        public async Task<IActionResult> GetArtist(string name)
        {
            var artist = await _service.ArtistService.GetArtistAsync(name);
            return Ok(artist);
        }
    }
}
