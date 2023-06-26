using MicroBroker.Song.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Song.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController: ControllerBase
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Models.Song>> ReadSong()
        {
            return Ok(_songService.ReadSong());
        }
        [HttpPost("readSongs")]
        public ActionResult<IEnumerable<Domain.Models.Song>> ReadSongs([FromBody]  List<int> idSongs)
        {

            return Ok(_songService.ReadSongs(idSongs));
        }

        [HttpGet("checkExistSong/{songName}")]
        public ActionResult<int> CheckExistSong(string songName)
        {
            return Ok(_songService.CheckExistSong(songName));

        }
        [HttpDelete("deleteSong/{id}")]
        public IActionResult DeleteSong(int id)
        {
            _songService.DeleteSong(id);
            return Ok(id);

        }

        [HttpPost("saveSong")]
        public IActionResult SaveSong([FromBody] Domain.Models.Song song)

        {
            _songService.SaveSong(song);
            return Ok(song);
        }
        [HttpPut("updateSong")]
        public IActionResult UpdateSong([FromBody] Domain.Models.Song song)

        {
            _songService.UpdateSong(song);
            return Ok(song);
        }
    }
}
