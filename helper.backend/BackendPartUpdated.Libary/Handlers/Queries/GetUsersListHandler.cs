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
    public class GetUsersListQuery : IRequest<Result<List<UserEntityDto>>>
    {
    }

    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, Result<List<UserEntityDto>>>
    {
        private readonly IDataRepository _dataRepository;

        public GetUsersListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<List<UserEntityDto>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var userList = await Task.FromResult(_dataRepository.GetUsers());

            //LINQ
            var result = new Result<List<UserEntityDto>>(userList.Select(x => new UserEntityDto(x.Id, x.Username, x.Email, x.Gender)).ToList());

            return result;
        }
    }
}