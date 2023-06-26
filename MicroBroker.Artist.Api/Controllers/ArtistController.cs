using MicroBroker.Artist.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Artist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController:ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }
        [HttpPost("checkExistArtist")]
        public IActionResult CheckExistArtist([FromBody] Domain.Models.Artist artist)
        {

            return Ok(_artistService.CheckExistArtist(artist));


        }
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Models.Artist>> ReadArtist()
        {
            return Ok(_artistService.ReadArtist());

        }
        [HttpPost("saveArtist")]
        public IActionResult SaveArtist([FromBody] Domain.Models.Artist artist)

        {
            _artistService.SaveArtist(artist);
            return Ok(artist);
        }
        [HttpPut("updateArtist")]
        public IActionResult UpdateArtist([FromBody] Domain.Models.Artist artist)

        {

            return Ok(_artistService.UpdateArtist(artist));
        }
        [HttpDelete("deleteArtist/{id}")]
        public IActionResult DeleteArtist(int id)
        {
            _artistService.DeleteArtist(id);
            return Ok(id);

        }


    }
}
