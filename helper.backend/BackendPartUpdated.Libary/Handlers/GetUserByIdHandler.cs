using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using BackendPartUpdated.DataManagment.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BackendPartUpdated.DataManagment.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserEntityDto>
    {
        private readonly IDataRepository _dataRepository;
        public GetUserByIdHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<UserEntityDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userList = await Task.FromResult(_dataRepository.GetUsers());
            var convertedListUser = new List<UserEntityDto>();

            foreach (UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }
            //TODO: if null the user exception
            var user = userList.FirstOrDefault(u => u.Id == request.id);
            var userDto = new UserEntityDto(user);
            return userDto;

        }
    }
}
