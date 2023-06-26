using MicroBroker.Domain.Core.Events;

namespace MicroBroker.Song.Domain.Events
{
    public class SongPlaylistGetEvent : Event
    {
        public List<int> IdSongsList { get; set; }

        public SongPlaylistGetEvent(List<int> idSongsList)
        {
            IdSongsList = idSongsList;
        }
    }
}
