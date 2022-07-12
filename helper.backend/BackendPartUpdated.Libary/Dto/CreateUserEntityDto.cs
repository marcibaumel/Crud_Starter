using BackendPartUpdated.DataManagment.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Dto
{
    public class CreateUserEntityDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public CreateUserEntityDto(int id, string username, string email, string gender)
        {
            Username = username;
            Email = email;
            Gender = gender;
        }

        public CreateUserEntityDto(UserEntity user)
        {
            try
            {
                Username = user.Username;
                Email = user.Email;
                Gender = user.Gender;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public CreateUserEntityDto() { }
    }

    /*
    public class UserValidator : AbstractValidator<CreateUserEntity>
    {
        public UserValidator()
        {
            RuleFor(t => t.Username).NotEmpty().WithMessage("Username is empty");
            RuleFor(t => t.Username.Trim()).MinimumLength(3).WithMessage("Username is too short");
            RuleFor(t => t.Username.Trim()).MaximumLength(15).WithMessage("Username is too long");
            RuleFor(t => t.Email.Trim()).EmailAddress().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Not good email format");
        }
    }
    */
}

