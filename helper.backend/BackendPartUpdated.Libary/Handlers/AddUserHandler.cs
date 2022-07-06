using BackendPartUpdated.DataManagment.Commands;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserEntity>
    {
        private readonly IDataRepository _dataRepository;

        public AddUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataRepository.AddUser(request.entity));
        }
    }
}
