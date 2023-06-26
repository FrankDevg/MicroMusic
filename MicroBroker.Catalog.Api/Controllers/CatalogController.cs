using MicroBroker.Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroBroker.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController:ControllerBase
    {
        //TODO: Validations in BL sin database..
        //public string Validations(ECatalog catalog)
        //{
        //    if (catalog.CodeCatalog == string.Empty || catalog.CodeCatalogParent == string.Empty)
        //    {
        //        return "Code or Code Parent catalog is required!";
        //    }
        //    if (catalog.Value == string.Empty)
        //    {
        //        return "A value for the Catalog is required!";
        //    }
        //    return string.Empty;
        //}

        // F
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost("checkExistCatalog")]
        public IActionResult CheckExistCatalog([FromBody] Domain.Models.Catalog catalog)
        {

            return Ok(_catalogService.CheckExistCatalog(catalog));


        }
        [HttpDelete("deleteCatalog/{id}")]
        public IActionResult DeleteCatalog(int id)
        {
            _catalogService.DeleteCatalog(id);
            return Ok(id);

        }
        [HttpGet("getPlaylistType")]
        public ActionResult<IEnumerable<Domain.Models.Catalog>> GetPlaylistType()
        {
            return Ok(_catalogService.GetPlaylistType());

        }
        [HttpGet("getUserType")]
        public ActionResult<IEnumerable<Domain.Models.Catalog>> GetUserType()
        {
            return Ok(_catalogService.GetUserType());

        }
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Models.Catalog>> ReadCatalog()
        {
            return Ok(_catalogService.ReadCatalog());
        }
        [HttpPost("saveCatalog")]
        public IActionResult SaveCatalog([FromBody] Domain.Models.Catalog catalog)

        {
            _catalogService.SaveCatalog(catalog);
            return Ok(catalog);
        }

        [HttpPut("updateCatalog")]
        public IActionResult UpdatePlaylist([FromBody] Domain.Models.Catalog catalog)

        {
            
            return Ok(_catalogService.UpdateCatalog(catalog));
        }



    }
}
