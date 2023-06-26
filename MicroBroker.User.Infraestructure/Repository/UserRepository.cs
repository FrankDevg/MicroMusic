using MediatR;
using MicroBroker.User.Domain.Interfaces;
using MicroBroker.User.Infraestructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.Models.User> ReadUsers()
        {
            return _context.Tbl_User;
        }
        
        public int SaveUser(Domain.Models.User user)
        {
            _context.Add(user);
            var cont =  _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar el usuario.");
        }
        public int UpdateUser(Domain.Models.User request)
        {
            var user =  _context.Tbl_User.Where(x => x.Id_User == request.Id_User)
                           .FirstOrDefault();
            if (user == null) throw new Exception("No se pudo encontrar el usuario.");

            user.Username = request.Username != null && request.Username != string.Empty ? request.Username : user.Username;
            user.Password = request.Password != null && request.Password != string.Empty ? request.Password : user.Password;
            user.Email = request.Email != null && request.Email != string.Empty ? request.Email : user.Email;
            user.Birthday = request.Birthday != null  ? request.Birthday : user.Birthday;
            user.User_Type = request.User_Type;
            user.User_Photo = request.User_Photo != null && request.User_Photo != string.Empty ? request.User_Photo : user.User_Photo;
            _context.Tbl_User.Update(user);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo actualizar el usuario.");
        }
        public int DeleteUser(int id)
        {
            var user = _context.Tbl_User.Where(x => x.Id_User == id)
                           .FirstOrDefault();
            if (user == null) return 0;
            _context.Tbl_User.Remove(user);
            var cont =  _context.SaveChanges();
            return cont;
            //throw new Exception("No se pudo eliminar el usuario.");
        }
        public int CheckExistUser(string username)
        {

            var user =  _context.Tbl_User.Where(x => x.Username == username)
                        .FirstOrDefault();
            
            return user == null?0: user.Id_User;
        }
        public int CheckExistEmail(string email)
        {
            


            var user = _context.Tbl_User.Where(x => x.Email == email)
                        .FirstOrDefault();
         
            return user == null?0: user.Id_User;
        }
        public Domain.Models.User AuthenticateUser(string userName, string password)
        {



            var user = _context.Tbl_User.Where(x => x.Username == userName)
                            .Where(x => x.Password == password)
                        .FirstOrDefault();
            //if (user == null)
            //{
            //    throw new Exception("No se encontro el usuario");
            //}
            return user;
        }

        System.Data.DataTable IUserRepository.Read()
        {
            DataTable dtUser = new DataTable();
            using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ID] ,[USERNAME] ,[PASSWORD] ,[EMAIL], [BIRTHDAY], [PHOTO],[USERTYPE] FROM [Tbl_User]", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dtUser);
                        return dtUser;
                    }
                }
            }

        }
    }
}
