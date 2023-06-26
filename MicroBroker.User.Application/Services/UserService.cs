using MicroBroker.Domain.Core.Bus;
using MicroBroker.User.Application.Interfaces;
using MicroBroker.User.Application.Models;
using MicroBroker.User.Domain.Commands;
using MicroBroker.User.Domain.Interfaces;
using System.Data;

namespace MicroBroker.User.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventBus _bus;

        public UserService(IUserRepository userRepository, IEventBus bus)
        {
            _userRepository = userRepository;
            _bus = bus;
        }



        public IEnumerable<Domain.Models.User> ReadUsers()
        {
            return _userRepository.ReadUsers();
        }
        public DataTable Read()
        {
            return _userRepository.Read();
        }
        public void CreatePlaylist(UserPlaylist userPlaylist)
        {
            var createUserPlaylistCommand = new CreateUserPlaylistCommand(
                userPlaylist.IdUser,
                userPlaylist.Title, 
                userPlaylist.CreationDate,
                userPlaylist.Type, 
                userPlaylist.Photo);

            _bus.SendCommand(createUserPlaylistCommand);
        }

        public int SaveUser(Domain.Models.User user)
        {
            return _userRepository.SaveUser(user);
        }
        public int UpdateUser(Domain.Models.User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public int DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
        public int CheckExistUser(string username)
        {
            return _userRepository.CheckExistUser(username);
        }
        public int CheckExistEmail(string email)
        {
            return _userRepository.CheckExistEmail(email);

        }
        public Domain.Models.User AuthenticateUser(string userName, string password)
        {
            var user = _userRepository.AuthenticateUser(userName, password);
            if (user != null)
            {
				var sendEmailUserLoginCommand = new SendEmailUserLoginCommand(
			 user.Id_User,
			 user.Username,
			 user.Email,
			 user.User_Type);
				_bus.SendCommand(sendEmailUserLoginCommand);
			}
            

			return user;
        }

    }
}
