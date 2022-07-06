using FluentValidation;

namespace BackendPartUpdated.DataManagment.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public UserEntity(int id, string username, string email, string gender)
        {
            Id = id;
            Username = username;
            Email = email;
            Gender = gender;
        }

    }
}
