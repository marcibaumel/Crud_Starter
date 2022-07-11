
using BackendPartUpdated.API.DTO;
using BackendPartUpdated.API.Services;
using BackendPartUpdated.DataManagment.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BackendPartUpdated.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserEntityDto>>> Get()
        {
            var userList = await _mediator.Send(new GetUserListQuery());
            return _userService.userEntityConverter(userList);
        }
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntityDto>> GetEntityById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost]
        public async Task<UserEntityDto> AddEntity(UserEntityDto user)
        {
            return await _userService.AddUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntityDto>>> DeleteEntityById(int id)
        {
            return await _userService.DeleteUser(id);
        }
        
        [HttpPut]
        public async Task<ActionResult<List<UserEntityDto>>> UpdateEntity([FromBody] UserEntityDto userRequest)
        {
            return await _userService.EditUser(userRequest);
        }
        */
    }
}
