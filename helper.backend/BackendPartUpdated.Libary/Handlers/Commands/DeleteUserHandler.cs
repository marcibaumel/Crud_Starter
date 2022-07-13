using BackendPartUpdated.DataManagment.Data;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Entities;
using MediatR;

namespace BackendPartUpdated.DataManagment.Handlers.Commands
{
    public record DeleteUserCommand(int id) : IRequest<List<UserEntityDto>>
    {
    }
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, List<UserEntityDto>>
    {
        private readonly IDataRepository _dataRepository;

        public DeleteUserHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<UserEntityDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: if null the user exception
            var userList = await _dataRepository.DeleteUser(request.id);
            var convertedListUser = new List<UserEntityDto>();

            foreach (UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return convertedListUser;
        }
    }
}
