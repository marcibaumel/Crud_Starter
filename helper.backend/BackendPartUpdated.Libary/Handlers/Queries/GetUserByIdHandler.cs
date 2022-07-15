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
    public record GetUserByIdQuery(int Id) : IRequest<Result<UserEntityDto>> 
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
            var user = await _dataRepository.GetUserById(request.Id);
            if (user is null)
            {
                return new Result<UserEntityDto>(null, "There is no data with this id", true);
            }
            return new Result<UserEntityDto>(new UserEntityDto(user));
        }
    }
}
