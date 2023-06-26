using MicroBroker.Album.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Application.Interfaces
{
    public interface ISongServiceRemote
    {
        Task<(bool resultado, List<SongRemote> songs, string ErrorMessage)> GetSongs(List<int> SongId);

    }
}
