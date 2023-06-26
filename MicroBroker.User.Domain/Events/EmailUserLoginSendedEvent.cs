using MicroBroker.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Domain.Events
{
	public class EmailUserLoginSendedEvent : Event
	{

		public int Id_User { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public int User_Type { get; set; }

		public EmailUserLoginSendedEvent(int idUser, string username,string email, int type)
		{
			Id_User = idUser;
			Username = username;
			Email = email;
			User_Type = type;
		}
	}
}
