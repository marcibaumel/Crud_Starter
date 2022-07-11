using BackendPartUpdated.DataManagment.Dto;

namespace BackendPartUpdated.API.Services
{
    public interface IUserService
    {
        List<UserEntityDto> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList);
        Task<List<UserEntityDto>> EditUser(UserEntityDto userEntity);
    }
}
