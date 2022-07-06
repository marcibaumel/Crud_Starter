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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, List<UserEntity>>
    {
        private readonly IDataRepository _dataRepository;

        public DeleteUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<List<UserEntity>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userList = _dataRepository.DeleteUser(request.id);
            return userList;
        }
    }
}
