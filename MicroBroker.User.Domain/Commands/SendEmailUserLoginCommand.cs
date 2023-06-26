using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Domain.Commands
{
	public class SendEmailUserLoginCommand: EmailUserLoginCommand
	{
		public SendEmailUserLoginCommand(int idUser, string username, string email, int user_Type)
		{
			Id_User = idUser;
			Username = username;
			Email = email;
			User_Type = user_Type;
		}
	}
}
