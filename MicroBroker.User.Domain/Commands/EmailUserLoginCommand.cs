
using MicroBroker.Domain.Core.Commands;

namespace MicroBroker.User.Domain.Commands
{
	public abstract class EmailUserLoginCommand:Command
	{
		public int Id_User { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public int User_Type { get; set; }
		

	}
}
