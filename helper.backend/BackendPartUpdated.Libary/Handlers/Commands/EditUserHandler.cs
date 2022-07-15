using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{

    public record EditUserCommand(UserEntityDto user) : IRequest<Result<List<UserEntityDto>>>
    {
        public int Id { get; set; } = user.Id;
        public string Username { get; set; } = user.Username;
        public string Email { get; set; } = user.Email;
        public string Gender { get; set; } = user.Gender;
    }

    public class EditUserHandler : IRequestHandler<EditUserCommand, Result<List<UserEntityDto>>>
    {
        private readonly IDataRepository _dataRepository;

        public EditUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<List<UserEntityDto>>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //Check if the user exsisting with the given id
            var user = await _dataRepository.GetUserById(request.Id);
            if (user is null)
            {
                return new Result<List<UserEntityDto>>(null, "There is no data with this Id in the database", true);  
            }
            //If there is a user with the given id, change the user data with the requested parameteres
            else
            {
                user.Username = request.user.Username;
                user.Email = request.user.Email;
                user.Gender = request.user.Gender;
            }
            
            //Fluent validation check
            EditUserValidator validator = new EditUserValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                //If there is a error send back an empty list
                return new Result<List<UserEntityDto>>(null, string.Join(", ", validationResult.Errors), true);   
            }

            var editedUserList = await _dataRepository.EditUser(user);

            //Give back the updated UserList
            var convertedListUser = new List<UserEntityDto>();
            foreach (UserEntity userEntity in editedUserList)
            {
                //Convert UserEntity to UserEntityDto
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }
            
            var result = new Result<List<UserEntityDto>>(convertedListUser);
            if (result.Data is null)
            {
                //If there is no data to send back, send back an empty list
                return new Result<List<UserEntityDto>>(null, "There is no data with this Id in the database", true);  
            }
           
            return result;
        }
    }
    
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserValidator()
        {
            RuleFor(t => t.Username).NotEmpty().WithMessage("Username is empty");
            RuleFor(t => t.Username.Trim()).MinimumLength(3).WithMessage("Username is too short");
            RuleFor(t => t.Username.Trim()).MaximumLength(15).WithMessage("Username is too long");
            RuleFor(t => t.Email.Trim()).EmailAddress().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Not good email format");
        }
    }
}
