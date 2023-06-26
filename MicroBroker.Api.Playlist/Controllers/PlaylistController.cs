using MicroBroker.Playlist.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Playlist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController:ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }
    [HttpGet]
    public ActionResult<IEnumerable<Domain.Models.Playlist>> Get()
        {
            return Ok(_playlistService.ReadPlaylist());
        }

        [HttpPost("savePlaylist")]
        public IActionResult SavePlaylist([FromBody] Domain.Models.Playlist playlist)

        {
            _playlistService.SavePlaylist(playlist);
            return Ok(playlist);
        }
        [HttpPut("updatePlaylist")]
        public IActionResult UpdatePlaylist([FromBody] Domain.Models.Playlist playlist)

        {
            _playlistService.UpdatePlaylist(playlist);
            return Ok(playlist);
        }
        [HttpDelete("deletePlaylist/{id}")]
        public IActionResult DeletePlaylist(int id)
        {
            _playlistService.DeletePlaylist(id);
            return Ok(id);

        }
        [HttpPost("checkExistPlaylist")]
        public IActionResult CheckExistPlaylist([FromBody] Domain.Models.Playlist playlist)
        {

            return Ok(_playlistService.CheckExistPlaylist(playlist));


        }
        [HttpGet("readPlaylist/{idUser}")]
        public ActionResult<IEnumerable<Domain.Models.Playlist>> ReadPlaylistsByIdUser(int idUser)
        {
            return Ok(_playlistService.ReadPlaylistsByIdUser(idUser));

        }
        [HttpGet("readPlaylistsIdUser/{idPlaylist}")]
        public ActionResult<Domain.Models.Playlist> ReadPlaylistByIdUserAndIdPlaylist(int idUser,int idPlaylist)
        {
            return Ok(_playlistService.ReadPlaylistByIdUserAndIdPlaylist(idUser,idPlaylist));

        }

    }


}

