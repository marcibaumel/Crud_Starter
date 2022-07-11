using BackendPartUpdated.API.DTO;

namespace BackendPartUpdated.API.Services
{
    public interface IUserService
    {
        List<UserEntityDto> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList);
        Task<List<UserEntityDto>> GetAllUser();
        Task<UserEntityDto> GetUserById(int id);
        Task<UserEntityDto> AddUser(UserEntityDto userEntity);
        Task<List<UserEntityDto>> DeleteUser(int id);
        Task<List<UserEntityDto>> EditUser(UserEntityDto userEntity);
    }
}
