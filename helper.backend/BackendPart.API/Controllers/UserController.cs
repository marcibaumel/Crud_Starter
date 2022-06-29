using BackendPart.API.Data;
using BackendPart.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BackendPart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetEntityById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("User not founded");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<UserEntity>>> AddEntity(UserEntity user)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = regex.Match(user.Email);

            if ((user.Username.Trim().Length > 3 && user.Username.Trim().Length < 15) && emailMatch.Success)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            }
            else
            {
                return BadRequest("Bad input data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<UserEntity>>> UpdateEntity([FromBody] UserEntity userRequest)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = regex.Match(userRequest.Email);

            if ((userRequest.Username.Trim().Length > 3 && userRequest.Username.Trim().Length < 15) && emailMatch.Success)
            {
                var user = await _context.Users.FindAsync(userRequest.Id);

                if (user == null)
                {
                    return BadRequest("User not founded");
                }

                user.Username = userRequest.Username;
                user.Email = userRequest.Email;
                user.Gender = userRequest.Gender;
                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            }
            else
            {
                return BadRequest("Bad input data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> DeleteEntityById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("User not founded");
            }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            }
        }
    }
}
