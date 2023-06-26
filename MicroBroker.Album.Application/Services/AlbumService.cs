using MicroBroker.Album.Application.Interfaces;
using MicroBroker.Album.Domain.Interfaces;
using MicroBroker.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Application.Services
{
    public class AlbumService:IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        //comunicacion microservicios

        private readonly IEventBus _bus;

        public AlbumService(IAlbumRepository albumRepository, IEventBus bus)
        {
            _albumRepository = albumRepository;
            _bus = bus;
        }

        public int CheckExistAlbum(string titleAlbum)
        {
            return _albumRepository.CheckExistAlbum(titleAlbum);

        }

        public int DeleteAlbum(int id)
        {
            return _albumRepository.DeleteAlbum(id);

        }

        public IEnumerable<Domain.Models.Album> ReadAlbum()
        {
            return _albumRepository.ReadAlbum();

        }

        public int SaveAlbum(Domain.Models.Album album)
        {
            return _albumRepository.SaveAlbum(album);

        }

        public int UpdateAlbum(Domain.Models.Album album)
        {
            return _albumRepository.UpdateAlbum(album);

        }
    }
}
