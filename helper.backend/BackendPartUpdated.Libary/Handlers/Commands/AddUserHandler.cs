using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{
    public record AddUserCommand(string Username, string Email, string Gender) : IRequest<Result<UserEntityDto>>;

    public class AddUserHandler : IRequestHandler<AddUserCommand, Result<UserEntityDto>>
    {
        /* 
         * querry
         * Handler
         * fluent validation
         */

        private readonly IDataRepository _dataRepository;

        public AddUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<UserEntityDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //propty name uppercase
            //mediator behaviors
            //exceptio wrapper -> generikus Result osztály
            var validator = new AddUserValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var convertedUser = new UserEntity(request.Username, request.Email, request.Gender);
                var user = await Task.FromResult(_dataRepository.AddUser(convertedUser));
                return new Result<UserEntityDto>(new UserEntityDto(user));
            }

            return new Result<UserEntityDto>(null, string.Join(", ", validationResult.Errors), true);
        }
    }

    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(t => t.Username).NotEmpty().WithMessage("Username is empty");
            RuleFor(t => t.Username.Trim()).MinimumLength(3).WithMessage("Username is too short");
            RuleFor(t => t.Username.Trim()).MaximumLength(15).WithMessage("Username is too long");
            RuleFor(t => t.Email.Trim()).EmailAddress().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Not good email format");
        }
    }
}
