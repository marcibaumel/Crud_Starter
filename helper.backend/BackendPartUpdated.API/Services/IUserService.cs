using BackendPartUpdated.API.DTO;

namespace BackendPartUpdated.API.Services
{
    public interface IUserService
    {
        List<UserEntity> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList);
        Task<List<UserEntity>> GetAllUser();
        Task<UserEntity> GetUserById(int id);
    }
}
