using MediatR;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.User.Domain.Commands;
using MicroBroker.User.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Domain.CommandHandlers
{
	public class EmailUserLoginCommandHandler : IRequestHandler<SendEmailUserLoginCommand, bool>
	{
		private readonly IEventBus _bus;

		public EmailUserLoginCommandHandler(IEventBus bus)
		{
			_bus = bus;
		}

		public Task<bool> Handle(SendEmailUserLoginCommand request, CancellationToken cancellationToken)
		{
			//logica para publicar el mensaje dentro del eventbus azure services bus.
			_bus.Publish(new EmailUserLoginSendedEvent(request.Id_User, request.Username, request.Email, request.User_Type));
			return Task.FromResult(true);
		}
	}
}
