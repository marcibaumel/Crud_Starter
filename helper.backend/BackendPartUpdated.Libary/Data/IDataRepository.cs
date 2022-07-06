using BackendPartUpdated.DataManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Data
{
    public interface IDataRepository
    {
        List<UserEntity> GetUsers();
        UserEntity AddUser(UserEntity user);
        Task<List<UserEntity>> DeleteUser(int id);
        Task<List<UserEntity>> EditUser(UserEntity userEntity);
    }
}
