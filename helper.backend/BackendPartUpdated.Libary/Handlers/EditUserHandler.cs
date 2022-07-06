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
    public class EditUserHandler:IRequestHandler<EditUserCommand, List<UserEntity>>
    {
        private readonly IDataRepository _dataRepository;

        public EditUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<List<UserEntity>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var userList = _dataRepository.EditUser(request.user);
            return userList;
        }
    }
}
