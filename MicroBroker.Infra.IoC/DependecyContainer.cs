using MediatR;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.Infra.Bus;
using MicroBroker.Playlist.Application.Interfaces;
using MicroBroker.Playlist.Application.Services;
using MicroBroker.Playlist.Infraestructure.Context;
using MicroBroker.Playlist.Infraestructure.Repository;
using MicroBroker.Playlist.Domain.Interfaces;
using MicroBroker.User.Application.Interfaces;
using MicroBroker.User.Application.Services;
using MicroBroker.User.Infraestructure.Context;
using MicroBroker.User.Infraestructure.Repository;
using MicroBroker.User.Domain.CommandHandlers;
using MicroBroker.User.Domain.Commands;
using MicroBroker.User.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Infra.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
         //   services.AddTransient<IRequestHandler<CreateUserPlaylistCommand, bool>, UserPlaylistCommandHandler>();
            //mediatr mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //domain Bus

            services.AddTransient<IEventBus, AzureServicesBus>();
            services.AddSingleton<IEventBus, AzureServicesBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<AzureServicesBusSettings>>();
                return new AzureServicesBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
            });



            // //application services
            // services.AddTransient<IUserService, UserService>();
            // services.AddTransient<IPlaylistService, PlaylistService>();

            // //DATA
            //services.AddTransient<IUserRepository, UserRepository>();
            // services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            // services.AddTransient<UserDbContext>();
            // services.AddTransient<PlaylistDbContext>();

            return services;

        }

    }
}
