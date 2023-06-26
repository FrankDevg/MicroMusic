
using MicroBroker.User.Application.Models;
using System.Data;

namespace MicroBroker.User.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Domain.Models.User> ReadUsers();
        DataTable Read();

        // CREATEPLAYLIST EJEMPLO DE COMUNICACION ENTRE MICROSERVICIOS
        void CreatePlaylist(UserPlaylist userPlaylist);
        int SaveUser(Domain.Models.User user);
        int UpdateUser(Domain.Models.User user);
        int DeleteUser(int id);
        int CheckExistUser(string username);
        int CheckExistEmail(string email);

        Domain.Models.User AuthenticateUser(string userName, string password);





    }
}
