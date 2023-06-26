using MicroBroker.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Domain.Events
{
    public class UserPlaylistCreatedEvent:Event
    {
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public int Type { get; set; }
        public string Photo { get; set; }

        public UserPlaylistCreatedEvent(int idUser, string title, string creationDate, int type, string photo)
        {
            IdUser = idUser;
            Title = title;
            CreationDate = creationDate;
            Type = type;
            Photo = photo;
        }
    }
}
