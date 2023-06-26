using MicroBroker.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.Commands
{
    public abstract class SongPlaylistCommand:Command
    {
        public List<int> idSongsList { get; set; }

        

    }
}
