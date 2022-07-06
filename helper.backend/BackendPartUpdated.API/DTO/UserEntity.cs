using FluentValidation;

namespace BackendPartUpdated.API.DTO
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

        public UserEntity(BackendPartUpdated.DataManagment.Entities.UserEntity user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Gender = user.Gender;
        }

        public UserEntity() { }
    }

    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {

            RuleFor(t => t.Username).NotEmpty().WithMessage("Username is empty");
            RuleFor(t => t.Username.Trim()).MinimumLength(3).WithMessage("Username is too short");
            RuleFor(t => t.Username.Trim()).MaximumLength(15).WithMessage("Username is too long");
            RuleFor(t => t.Email.Trim()).EmailAddress().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Not good email format");

        }
    }
}
