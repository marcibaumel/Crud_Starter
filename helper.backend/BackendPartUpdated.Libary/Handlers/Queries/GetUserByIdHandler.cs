using BackendPartUpdated.DataManagment.Common.Interfaces;
using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BackendPartUpdated.DataManagment.Handlers.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<Result<UserEntityDto>> 
    { 
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserEntityDto>>
    {
        private readonly IDataRepository _dataRepository;
        public GetUserByIdHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<UserEntityDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userList = await Task.FromResult(_dataRepository.GetUsers());
            var convertedListUser = new List<UserEntityDto>();
            var result = new Result<UserEntityDto>();

            foreach (UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }
           
            var user = userList.FirstOrDefault(u => u.Id == request.id);
            if (!(user is null))
            {
                result = new Result<UserEntityDto>(new UserEntityDto(user));
            }
            else
            {
                result = new Result<UserEntityDto>(null, "There is no data with this Id in the database", true);
            }
            
            return result;
        }
    }
}
