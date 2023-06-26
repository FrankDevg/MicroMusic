using MicroBroker.Album.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Album.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TracklistController : ControllerBase
    {
        private readonly ITracklistService _tracklistService;

        public TracklistController(ITracklistService tracklistService)
        {
            _tracklistService = tracklistService;
        }
        [HttpPost("checkExistTracklist/{idAlbum}/{idSong}")]
    public IActionResult CheckExistTracklist(int idAlbum, int idSong)
        {

            return Ok(_tracklistService.CheckExistTracklist(idAlbum, idSong));


        }
        [HttpPost("readTracklist/{idAlbum}")]
        public ActionResult<IEnumerable<Domain.Models.SongRemote>> ReadTracklist(int idAlbum)
        {
            return Ok(_tracklistService.ReadTracklist(idAlbum));

        }
        [HttpPost("saveTracklist/{idAlbum}/{idSong}")]
        public IActionResult SavePlayer(int idAlbum, int idSong)

        {

            return Ok(_tracklistService.SaveTracklist(idAlbum, idSong));
        }
        [HttpPost("saveTracklists/{idAlbum}")]
        public IActionResult SavePlayers(int idAlbum, List<int> idSong)

        {

            return Ok(_tracklistService.SaveTracklist(idAlbum, idSong));
        }
        [HttpDelete("deleteSongOnTracklist/{idAlbum}/{idSong}")]
        public IActionResult DeleteSongOnTracklist(int idAlbum, int idSong)
        {

            return Ok(_tracklistService.DeleteSongOnTracklist(idAlbum, idSong));

        }
        [HttpDelete("deleteTracklist/{idAlbum}")]
        public IActionResult DeleteTracklist(int idAlbum)
        {

            return Ok(_tracklistService.DeleteTracklist(idAlbum));

        }
    }
}
