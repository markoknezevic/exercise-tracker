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

            var isEmailTaken = await UnitOfWork.UsersRepository.IsEmailTakenAsync(userPostObject.Email);
            if (isEmailTaken)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            var isUserActiveAndExists = await UnitOfWork.UsersRepository.IsActiveUserExistsAsync(id);
            if (!isUserActiveAndExists)
            {
                return BadRequest();
            }

            var isUserDeleted = await UnitOfWork.UsersRepository.DeleteUserAsync(id);
            if (!isUserDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Put([FromBody] EditUserPutObject userPutObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isActiveUserExists = await UnitOfWork.UsersRepository.IsActiveUserExistsAsync(userPutObject.Id);
            if (!isActiveUserExists)
            {
                return BadRequest();
            }

            var editedUser = await UnitOfWork.UsersRepository.EditUserAsync(userPutObject.Id, userPutObject.FirstName,
                                                                            userPutObject.LastName, userPutObject.Password,
                                                                            userPutObject.DateOfBirth);

            if (editedUser == null)
            {
                return BadRequest();
            }

            var editedUserMapResult = Mapper.Map<User, UserDTO>(editedUser);

            return Ok(editedUserMapResult);
        }
    }
}