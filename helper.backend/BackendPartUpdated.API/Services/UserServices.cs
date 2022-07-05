using BackendPartUpdated.API.DTO;
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
            List<UserEntity> convertedListUser = new List<UserEntity>();
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
    }
}
