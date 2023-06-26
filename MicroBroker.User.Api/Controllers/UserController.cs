using MicroBroker.User.Application.Interfaces;
using MicroBroker.User.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Text;
using System.Web;

namespace MicroBroker.User.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Models.User>> ReadUsers()
        {
            return Ok(_userService.ReadUsers());
        }
        [HttpGet("read")]
        public ActionResult<IEnumerable<Domain.Models.User>> Read()
        {
            DataTable data = _userService.Read();
            IEnumerable<Domain.Models.User> response = data.AsEnumerable().Select(row => new Domain.Models.User
            {
                Id_User = Convert.ToInt32(row["Id_User"]),
                Username = row["Username"].ToString()  ,
                Password = row["Password"].ToString(),
                Email = row["Email"].ToString(),
                Birthday = Convert.ToDateTime(row["Birthday"]),
                User_Type = Convert.ToInt32(row["User_Type"]), 
                User_Photo = row["User_Photo"].ToString()  
           });



            return Ok(response);


        }
        //    [HttpPost("saveUser")]
        //    public async Task<ActionResult<Unit>> SaveUser(SaveUser.NewUser data)
        //    {
        //        return await _mediator.Send(data);
        //    }
        //************************************************************************************//
        //************************************************************************************//
        //************PRUEBA COMUNICACION ASINCRONA CON MICROSERVICIO PLAYLIST************//
        //************************************************************************************//
        //************************************************************************************//


        [HttpPost("savePlaylist")]
        public IActionResult Post([FromBody] UserPlaylist userPlaylist)

        {
            _userService.CreatePlaylist(userPlaylist);
            return Ok(userPlaylist);
        }

        //************************************************************************************//
        //************************************************************************************//
        [HttpPost("saveUser")]
        public IActionResult Post([FromBody] Domain.Models.User user)

        {
            _userService.SaveUser(user);
            return Ok(user);
        }
        [HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] Domain.Models.User user)

        {
            _userService.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            
            return Ok(_userService.DeleteUser(id));

        }
        [HttpGet("checkExistUser/{userName}")]
        public IActionResult CheckExistUser(string userName)
        {
            return Ok(_userService.CheckExistUser(userName));


        }
        [HttpGet("checkExistEmail/{email}")]
        public IActionResult CheckExistEmail(string email)
        {

            return Ok(_userService.CheckExistEmail(email));


        }
        [HttpGet("authenticateUser/{userName}/{password}")]
        public IActionResult AuthenticateUser(string userName, string password)
        {

            return Ok(_userService.AuthenticateUser(userName, password));


        }
     

    }


}
