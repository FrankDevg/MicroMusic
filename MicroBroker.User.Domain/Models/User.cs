using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Domain.Models
{

    public class User
    {
        public User()
        {
        }
        public User(int id, string username, string password, string email, DateTime birthday, int userType, string photo)
        {
            Id_User = id;
            Username = username;
            Password = password;
            Email = email;
            Birthday = birthday;
            User_Type = userType;
            User_Photo = photo;
        }
        [Key]
        public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public int User_Type { get; set; }
        // Generates CS8618, uninitialized non-nullable property:
        public string User_Photo { get; set; }
    }
}
