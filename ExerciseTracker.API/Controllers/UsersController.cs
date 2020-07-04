using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.Users;
using ExerciseTracker.API.Models.Users;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController<UsersController>
    {
        public UsersController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Post([FromBody] RegisterUserPostObject userPostObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UnitOfWork.UsersRepository.IsEmailTaken(userPostObject.Email))
            {
                return BadRequest();
            }
            
            var savedUser = await UnitOfWork.UsersRepository.RegisterUserAsync(new User()
            {
                FirstName = userPostObject.FirstName,
                LastName = userPostObject.LastName,
                Email = userPostObject.Email,
                Password = userPostObject.Password,
                DateOfBirth = userPostObject.DateOfBirth,
                StatusId = (short) Statuses.Active
            });

            if (savedUser == null)
            {
                return BadRequest();
            }

            var userMapResult = Mapper.Map<User, UserDTO>(savedUser);

            return userMapResult;
        }
        
    }
}