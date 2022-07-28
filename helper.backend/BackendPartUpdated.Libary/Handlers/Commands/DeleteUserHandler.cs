using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{
    public record DeleteUserCommand(int Id) : IRequest<Result<bool>>
    {
    }
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
    {
        private readonly IDataRepository _dataRepository;

        public DeleteUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if(await _dataRepository.DeleteUser(request.Id))
            {
                return new Result<bool>(true);
            }
            else
            {
                return new Result<bool>(false, "There is no user with the given Id", true);
            }
        }
    }
}
