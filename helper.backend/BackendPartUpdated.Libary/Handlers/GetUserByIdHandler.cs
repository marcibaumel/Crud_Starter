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
    public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        private readonly IMediator _mediator;
        public GetUserByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetUserListQuery());
            var user = users.FirstOrDefault(u => u.Id == request.id);
            return user;
        }
    }
}
