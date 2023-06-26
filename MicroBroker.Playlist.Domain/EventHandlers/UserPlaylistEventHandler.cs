using MicroBroker.Domain.Core.Bus;
using MicroBroker.Playlist.Domain.Events;
using MicroBroker.Playlist.Domain.Interfaces;

namespace MicroBroker.Playlist.Domain.EventHandlers
{ 


public class UserPlaylistEventHandler : IEventHandler<UserPlaylistCreatedEvent>
{
    private readonly IPlaylistRepository _playlistRepository;

            public UserPlaylistEventHandler(IPlaylistRepository playlistRepository)
            {
                _playlistRepository = playlistRepository;
            }

        //se ejecuta cuando llega un mensaje al bus
        public Task Handle(UserPlaylistCreatedEvent @event)
        {
            var playlist = new Domain.Models.Playlist
            {
                Id_Playlist = 0,
                Creation_Date = @event.Creation_Date,
                Id_User = @event.Id_User,
                Photo = @event.User_Photo,
                Title = @event.Title,
                Type = @event.User_Type

            };

            _playlistRepository.AddPlaylist(playlist);


            return Task.CompletedTask;
        }

    }
}
