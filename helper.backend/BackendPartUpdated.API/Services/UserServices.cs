using BackendPartUpdated.API.DTO;
using BackendPartUpdated.DataManagment.Commands;
using BackendPartUpdated.DataManagment.Queries;
using MediatR;

namespace BackendPartUpdated.API.Services
{
    public class UserServices : IUserService
    {
        private readonly IMediator _mediator;

        public UserServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<UserEntityDto> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList)
        {
            var convertedListUser = new List<UserEntityDto>();
            foreach (BackendPartUpdated.DataManagment.Entities.UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return convertedListUser;
        }

        public async Task<List<UserEntityDto>> GetAllUser()
        {
            var userList = await _mediator.Send(new GetUserListQuery());
            return userEntityConverter(userList);
        }

        public async Task<UserEntityDto> GetUserById(int id)
        {
            var user = new UserEntityDto(await _mediator.Send(new GetUserByIdQuery(id)));
            return user;
        }

        public async Task<UserEntityDto> AddUser(UserEntityDto userEntity)
        {
            var convertedUser = new BackendPartUpdated.DataManagment.Entities.UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender);
            var user = new UserEntityDto(await _mediator.Send(new AddUserCommand(convertedUser)));
            return user;
        }

        public async Task<List<UserEntityDto>> DeleteUser(int id)
        {
            var userList = await _mediator.Send(new DeleteUserCommand(id));
            return userEntityConverter(userList);
        }

        public async Task<List<UserEntityDto>> EditUser(UserEntityDto userEntity)
        {
            var convertedUser = new BackendPartUpdated.DataManagment.Entities.UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender);
            var userList = await _mediator.Send(new EditUserCommand(convertedUser));
            return userEntityConverter(userList);
        }
    }
}
