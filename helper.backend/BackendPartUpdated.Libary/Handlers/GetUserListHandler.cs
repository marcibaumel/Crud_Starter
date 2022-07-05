using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Entities;
using BackendPartUpdated.DataManagment.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Handlers
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserEntity>>
    {
        private readonly IDataRepository _dataRepository;

        public GetUserListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<List<UserEntity>> Handle (GetUserListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataRepository.GetUsers());
        }
    }
}
