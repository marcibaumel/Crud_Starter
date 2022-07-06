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

        public List<UserEntity> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList)
        {
            var convertedListUser = new List<UserEntity>();
            foreach (BackendPartUpdated.DataManagment.Entities.UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return convertedListUser;
        }

        public async Task<List<UserEntity>> GetAllUser()
        {
            var userList = await _mediator.Send(new GetUserListQuery());
            return userEntityConverter(userList);
        }

        public async Task<UserEntity> GetUserById(int id)
        {
            var user = new UserEntity(await _mediator.Send(new GetUserByIdQuery(id)));
            return user;
        }

        public async Task<UserEntity> AddUser(UserEntity userEntity)
        {
            var convertedUser = new BackendPartUpdated.DataManagment.Entities.UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender);
            var user = new UserEntity(await _mediator.Send(new AddUserCommand(convertedUser)));
            return user;
        }

        public async Task<List<UserEntity>> DeleteUser(int id)
        {
            var userList = await _mediator.Send(new DeleteUserCommand(id));
            return userEntityConverter(userList);
        }

        public async Task<List<UserEntity>> EditUser(UserEntity userEntity)
        {
            var convertedUser = new BackendPartUpdated.DataManagment.Entities.UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender);
            var userList = await _mediator.Send(new EditUserCommand(convertedUser));
            return userEntityConverter(userList);
        }
    }
}
