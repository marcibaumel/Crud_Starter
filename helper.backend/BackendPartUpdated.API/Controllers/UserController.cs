
using BackendPartUpdated.API.DTO;
using BackendPartUpdated.DataManagment.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BackendPartUpdated.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> Get()
        {
            var userList = await _mediator.Send(new GetUserListQuery());
            List<UserEntity> convertedListUser = new List<UserEntity>();
            foreach (BackendPartUpdated.DataManagment.Entities.UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }
            return convertedListUser;
        }

        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetEntityById(int id)
        {
            
        }

        [HttpPost]
        public async Task<ActionResult<List<UserEntity>>> AddEntity(UserEntity user)
        {
           
        }

        [HttpPut]
        public async Task<ActionResult<List<UserEntity>>> UpdateEntity([FromBody] UserEntity userRequest)
        {
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> DeleteEntityById(int id)
        {
           
        }
        */
    }
}
