using MicroBroker.Domain.Core.Events;


namespace MicroBroker.Playlist.Domain.Events
{
    public class UserPlaylistCreatedEvent : Event
    {
        public int Id_User { get; set; }
        public string Title { get; set; }
        public DateTime Creation_Date { get; set; }
        public int User_Type { get; set; }
        public string User_Photo { get; set; }

        public UserPlaylistCreatedEvent(int idUser, string title, DateTime creationDate, int type, string photo)
        {
            Id_User = idUser;
            Title = title;
            Creation_Date = creationDate;
            User_Type = type;
            User_Photo = photo;
        }

    }
}
