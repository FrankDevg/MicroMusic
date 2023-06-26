using MicroBroker.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.Events
{
    public class SongPlaylistGetEvent:Event
    {
        public List<int> IdSongsList { get; set; }

        public SongPlaylistGetEvent(List<int> idSongsList)
        {
            IdSongsList = idSongsList;
        }
    }
}
