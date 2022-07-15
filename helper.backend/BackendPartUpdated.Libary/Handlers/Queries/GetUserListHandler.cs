using BackendPartUpdated.DataManagment.Common.Interfaces;
using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Handlers.Queries
{
    public class GetUserListQuery : IRequest<Result<List<UserEntityDto>>>
    {
    }

    public class GetUserListHandler : IRequestHandler<GetUserListQuery, Result<List<UserEntityDto>>>
    {
        private readonly IDataRepository _dataRepository;

        public GetUserListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<List<UserEntityDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await Task.FromResult(_dataRepository.GetUsers());
            var convertedListUser = new List<UserEntityDto>();

            foreach (UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            var result = new Result<List<UserEntityDto>>(convertedListUser);
            if(result.Data == null)
            {
                return new Result<List<UserEntityDto>>(null, "There is no data", true);
            }
            return result;
        }
    }
}