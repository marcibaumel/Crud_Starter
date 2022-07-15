using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Handlers.Commands;
using BackendPartUpdated.DataManagment.Handlers.Queries;
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
        public async Task<ActionResult<List<UserEntityDto>>> Get()
        {
            var data =  await _mediator.Send(new GetUserListQuery());
            if (data.HasError)
            {
                return BadRequest(data.Messages);
            }
            return Ok(data.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntityDto>> GetEntityById(int id)
        {
            var data = await _mediator.Send(new GetUserByIdQuery(id));
            if (data.HasError)
            {
                return BadRequest(data.Messages);
            }
            return Ok(data.Data);
        }

        [HttpPost]
        public async Task<ActionResult<UserEntityDto>> AddEntity(AddUserCommand user)
        {
            var data = await _mediator.Send(user);
            if (data.HasError)
            {
                return BadRequest(data.Messages);
            }
            return Ok(data.Data);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntityDto>>> DeleteEntityById(int id)
        {
            var data = await _mediator.Send(new DeleteUserCommand(id));
            if (data.HasError)
            {
                return BadRequest(data.Messages);
            }
            return Ok(data.Data);
        }
        
        [HttpPut]
        public async Task<ActionResult<List<UserEntityDto>>> UpdateEntity([FromBody] UserEntityDto userRequest)
        {
            var data = await _mediator.Send(new EditUserCommand(userRequest));
            if (data.HasError)
            {
                return BadRequest(data.Messages);
            }
            return Ok(data.Data);
        }
    }
}
