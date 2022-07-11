using BackendPartUpdated.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.Services.UserServices
{
    public interface IUserService
    {
        List<UserEntityDto> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList);
    }
}
