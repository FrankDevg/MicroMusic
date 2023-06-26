using MicroBroker.Artist.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Artist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController:ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost("checkExistPlayer")]
        public IActionResult CheckExistPlayer(int idArtist, int idSong)
        {

            return Ok(_playerService.CheckExistPlayer(idArtist, idSong));


        }
        [HttpPost("readPlayer/{idArtist}")]
        public ActionResult<IEnumerable<Domain.Models.SongRemote>> ReadPlayer(int idArtist)
        {
            return Ok(_playerService.ReadPlayer(idArtist));

        }
        [HttpPost("savePlayer/{idArtist}/{idSong}")]
        public IActionResult SavePlayer(int idArtist, int idSong)

        {

            return Ok(_playerService.SavePlayer(idArtist, idSong));
        }
        [HttpPost("savePlayers/{idArtist}")]
        public IActionResult SavePlayers( int idArtist,  List<int> idSong)

        {

            return Ok(_playerService.SavePlayer(idArtist, idSong));
        }
        [HttpDelete("deletePlayer/{idArtist}/{idSong}")]
        public IActionResult DeletePlayer(int idArtist, int idSong)
        {

            return Ok(_playerService.DeletePlayer (idArtist, idSong));

        }
        [HttpDelete("deletePlayer/{idArtist}")]
        public IActionResult DeletePlayer(int idArtist)
        {

            return Ok(_playerService.DeletePlayer(idArtist));

        }

    }
}
