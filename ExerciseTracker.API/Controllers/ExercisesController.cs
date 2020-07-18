using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.Exercises;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : BaseController<ExercisesController>
    {
        public ExercisesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet]
        [ProducesResponseType(typeof(List<ExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<ExerciseDTO>>> Get()
        {
            var exercises = await UnitOfWork.ExercisesRepository.GetAllExercisesAsync();
            if (exercises == null || exercises.Count == 0)
            {
                return NoContent();
            }

            var exercisesMapResult = Mapper.Map<List<Exercise>, List<ExerciseDTO>>(exercises);

            return exercisesMapResult;
        }
    }
}