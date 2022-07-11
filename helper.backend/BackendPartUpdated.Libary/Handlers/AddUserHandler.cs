using BackendPartUpdated.DataManagment.Commands;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserEntityDto>
    {
        private readonly IDataRepository _dataRepository;

        public AddUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<UserEntityDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var convertedUser = new UserEntity(request.entity.Username, request.entity.Email, request.entity.Gender);
            var user = await Task.FromResult(_dataRepository.AddUser(convertedUser));
            return new UserEntityDto(user);
        }

        
    }
}
