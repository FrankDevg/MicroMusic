using MicroBroker.Domain.Core.Commands;


namespace MicroBroker.User.Domain.Commands
{
    public abstract class UserPlaylistCommand:Command
    {
        public int Id_User { get; protected set; }
        public string Title { get; protected set; }
        public string Creation_Date { get; protected set; }
        public int User_Type { get; protected set; }
        public string User_Photo { get; protected set; }
    }
}
