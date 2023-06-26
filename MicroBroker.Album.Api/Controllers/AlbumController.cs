using MicroBroker.Album.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Album.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase

    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Domain.Models.Album>> ReadAlbum()
        {
            return Ok(_albumService.ReadAlbum());
        }
        [HttpGet("checkExistAlbum/{albumTitle}")]
        public ActionResult<int> CheckExistAlbum(string albumTitle)
        {
            return Ok(_albumService.CheckExistAlbum(albumTitle));

        }
        [HttpDelete("deleteAlbum/{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);
            return Ok(id);

        }

        [HttpPost("saveAlbum")]
        public IActionResult SaveAlbum([FromBody] Domain.Models.Album album)

        {
            _albumService.SaveAlbum(album);
            return Ok(album);
        }
        [HttpPut("updateAlbum")]
        public IActionResult UpdateAlbum([FromBody] Domain.Models.Album album)

        {
            _albumService.UpdateAlbum(album);
            return Ok(album);
        }

    }
}
