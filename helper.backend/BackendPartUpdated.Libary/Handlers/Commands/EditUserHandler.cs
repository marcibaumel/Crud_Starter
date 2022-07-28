using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{

    public record EditUserCommand(int Id, string Username, string Email, string Gender) : IRequest<Result<bool>>;

    public class EditUserHandler : IRequestHandler<EditUserCommand, Result<bool>>
    {
        private readonly IDataRepository _dataRepository;

        public EditUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<bool>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //Fluent validation check
            var validator = new EditUserValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                //If there is a error send back an empty list
                return new Result<bool>(false, string.Join(", ", validationResult.Errors), true);
            }

            //Check if the user exsisting with the given id
            var user = await _dataRepository.GetUserById(request.Id);

            if (user is null)
            {
                return new Result<bool>(false, "There is no user with the given Id", true);
            }

            user.Username = request.Username;
            user.Email = request.Email;
            user.Gender = request.Gender;

            await _dataRepository.SaveChangesAsync();

            return new Result<bool>(true);

            ////LINQ
            //foreach (var userEntity in editedUserList)
            //{
            //    //Convert UserEntity to UserEntityDto
            //    convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            //}

            //var convertedListUser = editedUserList.Select(x => new UserEntityDto(x.Id, x.Username, x.Email, x.Gender)).ToList();

            //Felesleges, LINQ, Reocrd class interface vs class, Edit, feladatok sorrende
            //if (result.Data is null)
            //{
            //    //If there is no data to send back, send back an empty list
            //    return new Result<List<UserEntityDto>>(null, "There is no data with this Id in the database", true);  
            //}
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
