using System;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.Users;
using ExerciseTracker.API.DTOs.Workouts;
using ExerciseTracker.API.Models.Workouts;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : BaseController<WorkoutsController>
    {
        public WorkoutsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpPost]
        [ProducesResponseType(typeof(WorkoutDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WorkoutDTO>> Post([FromBody] WorkoutPostObject workoutPostObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isActiveUserExists = await UnitOfWork.UsersRepository.IsActiveUserExistsAsync(workoutPostObject.UserId);
            if (!isActiveUserExists)
            {
                return BadRequest();
            }
            
            var savedWorkout = await UnitOfWork.WorkoutsRepository.AddWorkoutAsync(new Workout()
            {
                Name = workoutPostObject.Name,
                Description = workoutPostObject.Description,
                StatusId = (short) Statuses.Active,
                UserId = workoutPostObject.UserId
            });

            if (savedWorkout == null)
            {
                return BadRequest();
            }

            var savedWorkoutMapResult = Mapper.Map<Workout, WorkoutDTO>(savedWorkout);

            return Created(String.Empty, savedWorkoutMapResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            var isActiveWorkoutExists =  await UnitOfWork.WorkoutsRepository.IsActiveWorkoutExistsAsync(id);
            if (!isActiveWorkoutExists)
            {
                return BadRequest();
            }

            var isWorkoutDeleted = await UnitOfWork.WorkoutsRepository.DeleteWorkoutAsync(id);
            if (!isWorkoutDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}