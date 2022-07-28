using BackendPartUpdated.DataManagment.Entities;

namespace BackendPartUpdated.DataManagment.Data
{
    public interface IDataRepository
    {
        List<UserEntity> GetUsers();
        UserEntity AddUser(UserEntity user);
        Task<bool> DeleteUser(int id);
        Task<UserEntity> GetUserById (int id);
        Task SaveChangesAsync();
    }
}
