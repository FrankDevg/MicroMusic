using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Domain.Commands
{
    public class CreateUserPlaylistCommand : UserPlaylistCommand
    {
        public CreateUserPlaylistCommand(int idUser, string title, string creationDate, int type, string photo)
        {
            Id_User = idUser;
            Title = title;
            Creation_Date = creationDate;
            User_Type = type;
            User_Photo = photo;

        }
    }
}
