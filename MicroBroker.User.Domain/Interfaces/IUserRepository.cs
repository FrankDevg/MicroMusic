using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MicroBroker.User.Domain.Models;

namespace MicroBroker.User.Domain.Interfaces
{
   public interface IUserRepository
    {
        IEnumerable<Domain.Models.User> ReadUsers();
        DataTable Read();
        int SaveUser(Domain.Models.User user);
        int UpdateUser(Domain.Models.User user);
        int DeleteUser(int id);
        int CheckExistUser(string username);
        int CheckExistEmail(string email);
        Domain.Models.User AuthenticateUser(string userName, string password);






    }
}
