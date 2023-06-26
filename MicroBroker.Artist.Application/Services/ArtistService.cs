using MicroBroker.Artist.Application.Interfaces;
using MicroBroker.Artist.Domain.Interfaces;
using MicroBroker.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Application.Services
{
    public class ArtistService : IArtistService
    {

        private readonly IArtistRepository _artistRepository;
        private readonly IEventBus _bus;

        public ArtistService(IArtistRepository artistRepository, IEventBus bus)
        {
            _artistRepository = artistRepository;
            _bus = bus;
        }
        public int CheckExistArtist(Domain.Models.Artist artist)
        {
            return _artistRepository.CheckExistArtist(artist);

        }

        public int DeleteArtist(int id)
        {
            return _artistRepository.DeleteArtist(id);

        }

        public IEnumerable<Domain.Models.Artist> ReadArtist()
        {
            return _artistRepository.ReadArtist();

        }

        public int SaveArtist(Domain.Models.Artist artist)
        {
            return _artistRepository.SaveArtist(artist);

        }

        public int UpdateArtist(Domain.Models.Artist artist)
        {
            return _artistRepository.UpdateArtist(artist);

        }
    }
}
