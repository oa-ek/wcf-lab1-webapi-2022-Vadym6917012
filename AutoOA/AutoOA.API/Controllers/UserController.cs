using AutoOA.Core;
using AutoOA.Repository.Dto.UserDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UsersRepository _usersRepository;

        public UserController(ILogger<UserController> logger, UsersRepository usersRepository)
        {
            _logger = logger;
            _usersRepository = usersRepository;
        }

        [HttpGet("GetUser")]
        public async Task<IEnumerable<UserReadDto>> GetListAsync()
        {
            return await _usersRepository.GetListAsync();
        }
        

    }
}
