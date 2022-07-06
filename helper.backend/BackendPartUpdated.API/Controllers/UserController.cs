
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
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> Get()
        {
            return await _userService.GetAllUser();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetEntityById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost]
        public async Task<UserEntity> AddEntity(UserEntity user)
        {
            return await _userService.AddUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> DeleteEntityById(int id)
        {
            return await _userService.DeleteUser(id);
        }
        
        [HttpPut]
        public async Task<ActionResult<List<UserEntity>>> UpdateEntity([FromBody] UserEntity userRequest)
        {
            return await _userService.EditUser(userRequest);
        }
    }
}
