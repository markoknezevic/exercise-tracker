using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.ExerciseWorkouts;
using ExerciseTracker.API.Models.ExerciseWorkouts;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseWorkoutsController : BaseController<ExerciseWorkoutsController>
    {
        public ExerciseWorkoutsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{workoutId}")]
        [ProducesResponseType(typeof(List<ExerciseWorkoutDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ExerciseWorkoutDTO>>> Get([FromRoute] long workoutId)
        {
            var isExerciseWorkoutExists = await UnitOfWork.ExerciseWorkoutsRepository.IsWorkoutExistInExerciseWorkoutAsync(workoutId);
            if (!isExerciseWorkoutExists)
            {
                return BadRequest();
            }
            
            var exerciseWorkouts = await UnitOfWork.ExerciseWorkoutsRepository.GetExerciseWorkoutsByIdAsync(workoutId);
            if (exerciseWorkouts == null || exerciseWorkouts.Count == 0)
            {
                return BadRequest();
            }
            
            var exerciseWorkoutMapResult = Mapper.Map<List<ExerciseWorkout>, List<ExerciseWorkoutDTO>>(exerciseWorkouts);

            return Ok(exerciseWorkoutMapResult);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(List<ExerciseWorkoutPostObject>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ExerciseWorkoutDTO>> Post([FromBody] List<ExerciseWorkoutPostObject> exerciseWorkoutPostObjects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var exerciseWorkoutsToBeSaved = Mapper.Map<List<ExerciseWorkoutPostObject>, List<ExerciseWorkout>>(exerciseWorkoutPostObjects);
            
            var savedExerciseWorkouts = await UnitOfWork.ExerciseWorkoutsRepository.AddExerciseWorkoutListAsync(exerciseWorkoutsToBeSaved);

            if (savedExerciseWorkouts == null)
            {
                return BadRequest();
            }

            var savedExerciseWorkoutsMapResult = Mapper.Map<List<ExerciseWorkout>, List<ExerciseWorkoutDTO>>(savedExerciseWorkouts);

            return Ok(savedExerciseWorkoutsMapResult);
        }
    }
}