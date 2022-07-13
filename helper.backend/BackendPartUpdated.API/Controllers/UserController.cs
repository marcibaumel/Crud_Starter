﻿using BackendPartUpdated.DataManagment.Dto;
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
            return await _mediator.Send(new GetUserListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntityDto>> GetEntityById(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        [HttpPost]
        public async Task<UserEntityDto> AddEntity(AddUserCommand user)
        {
            return await _mediator.Send(user);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntityDto>>> DeleteEntityById(int id)
        {
            return await _mediator.Send(new DeleteUserCommand(id));
        }
        
        [HttpPut]
        public async Task<ActionResult<List<UserEntityDto>>> UpdateEntity([FromBody] UserEntityDto userRequest)
        {
            return await _mediator.Send(new EditUserCommand(userRequest));
        }
    }
}
