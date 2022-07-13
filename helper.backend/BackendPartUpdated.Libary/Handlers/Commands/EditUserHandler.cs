using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{

    public record EditUserCommand(UserEntityDto user) : IRequest<List<UserEntityDto>>
    {
        public int Id { get; set; } = user.Id;
        public string Username { get; set; } = user.Username;
        public string Email { get; set; } = user.Email;
        public string Gender { get; set; } = user.Gender;
    }

    public class EditUserHandler : IRequestHandler<EditUserCommand, List<UserEntityDto>>
    {
        private readonly IDataRepository _dataRepository;

        public EditUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<UserEntityDto>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var userList = await Task.FromResult(_dataRepository.GetUsers());

            //TODO: if null the user exception
            var user = userList.FirstOrDefault(u => u.Id == request.user.Id);

            user.Username = request.user.Username;
            user.Email = request.user.Email;
            user.Gender = request.user.Gender;

            EditUserValidator validator = new EditUserValidator();

            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                var errors = results.Errors;
            }

            var editedUserList = await _dataRepository.EditUser(user);

            var convertedListUser = new List<UserEntityDto>();
            foreach (UserEntity userEntity in editedUserList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return convertedListUser;
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
