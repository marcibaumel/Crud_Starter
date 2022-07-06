using BackendPartUpdated.API.DTO;

namespace BackendPartUpdated.API.Services
{
    public interface IUserService
    {
        List<UserEntity> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList);
        Task<List<UserEntity>> GetAllUser();
        Task<UserEntity> GetUserById(int id);
        Task<UserEntity> AddUser(UserEntity userEntity);
        Task<List<UserEntity>> DeleteUser(int id);
        Task<List<UserEntity>> EditUser(UserEntity userEntity);
    }
}
