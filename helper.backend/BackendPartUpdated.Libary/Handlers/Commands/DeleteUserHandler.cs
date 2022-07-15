using BackendPartUpdated.DataManagment.Common.Models;
using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{
    public record DeleteUserCommand(int id) : IRequest<Result<List<UserEntityDto>>>
    {
    }
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<List<UserEntityDto>>>
    {
        private readonly IDataRepository _dataRepository;

        public DeleteUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Result<List<UserEntityDto>>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userList = await _dataRepository.DeleteUser(request.id);
            if(userList is null)
            {
                return new Result<List<UserEntityDto>>(null, "There is no data with this id", true);
            }
            var convertedListUser = new List<UserEntityDto>();

            foreach (UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return new Result<List<UserEntityDto>>(convertedListUser);
        }
    }
}
