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
            return user;
        }

        public List<UserEntity> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
