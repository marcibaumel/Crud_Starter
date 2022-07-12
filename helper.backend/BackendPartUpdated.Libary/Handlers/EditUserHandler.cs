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
    public class EditUserHandler:IRequestHandler<EditUserCommand, List<UserEntityDto>>
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

            var editedUserList = await _dataRepository.EditUser(user);

            var convertedListUser = new List<UserEntityDto>();
            foreach (UserEntity userEntity in editedUserList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return convertedListUser;
        }
    }
}
