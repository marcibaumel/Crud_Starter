using BackendPartUpdated.DataManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context;

        public DataRepository(DataContext context)
        {
            _context = context;
        }

        public UserEntity AddUser(UserEntity user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<List<UserEntity>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return _context.Users.ToList();
            }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return _context.Users.ToList();
            }
        }

        public async Task<List<UserEntity>> EditUser(UserEntity userRequest)
        {
            var user = await _context.Users.FindAsync(userRequest.Id);

            if (user == null)
            {
                return _context.Users.ToList();
            }
            else
            {
                user.Username = userRequest.Username;
                user.Email = userRequest.Email;
                user.Gender = userRequest.Gender;
                await _context.SaveChangesAsync();
                return _context.Users.ToList();
            };
        }

        public List<UserEntity> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
