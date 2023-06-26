using MicroBroker.Playlist.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Playlist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongController : ControllerBase
    {
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistSongController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }
        [HttpPost("readPlaylistSong/{idPlaylist}")]
        public ActionResult<IEnumerable<Domain.Models.SongRemote>> ReadPlaylistSong(int idPlaylist)
        {
            return Ok(_playlistSongService.ReadPlaylistSong(idPlaylist));
        }

        [HttpPost("savePlaylistSong/{idPlaylist}/{idSong}")]
        public IActionResult SavePlaylistSong( int idPlaylist, int idSong)

        {
            
            return Ok(_playlistSongService.SavePlaylistSong(idPlaylist, idSong));
        }
        
        [HttpDelete("deletePlaylistSong/{idPlaylist}/{idSong}")]
        public IActionResult DeletePlaylistSong(int idPlaylist,int idSong)
        {
            
            return Ok(_playlistSongService.DeletePlaylistSong(idPlaylist, idSong));

        }
        [HttpDelete("deletePlaylistSong/{idPlaylist}/")]
        public IActionResult DeletePlaylistSong(int idPlaylist)
        {

            return Ok(_playlistSongService.DeletePlaylistSong(idPlaylist));

        }
        [HttpPost("checkExistPlaylistSong")]
        public IActionResult CheckExistPlaylistSong( int playlistId, int songId)
        {

            return Ok(_playlistSongService.CheckExistPlaylistSong(playlistId, songId));


        }



    }
}
