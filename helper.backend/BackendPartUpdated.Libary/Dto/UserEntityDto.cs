using BackendPartUpdated.DataManagment.Entities;
using FluentValidation;

namespace BackendPartUpdated.DataManagment.Dto
{
    public class UserEntityDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public UserEntityDto(int id, string username, string email, string gender)
        {
            Id = id;
            Username = username;
            Email = email;
            Gender = gender;
        }

        public UserEntityDto(UserEntity user)
        {
            try
            {
                Id = user.Id;
                Username = user.Username;
                Email = user.Email;
                Gender = user.Gender;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public UserEntityDto() { }
    }
}
