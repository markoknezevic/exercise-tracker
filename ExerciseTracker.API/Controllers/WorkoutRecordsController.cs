using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.WorkoutRecords;
using ExerciseTracker.API.Models.WorkoutRecords;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutRecordsController : BaseController<WorkoutRecordsController>
    {
        public WorkoutRecordsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpPost]
        [ProducesResponseType(typeof(WorkoutRecordDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WorkoutRecordDTO>> Post(WorkoutRecordPostObject workoutRecordPostObject)
        {
            var isActiveWorkoutExists = await UnitOfWork.WorkoutsRepository.IsActiveWorkoutExistsAsync(workoutRecordPostObject.WorkoutId);
            if (!isActiveWorkoutExists)
            {
                return BadRequest();
            }

            var savedWorkoutRecord = await UnitOfWork.WorkoutRecordsRepository.AddWorkoutRecordAsync(new WorkoutRecord()
            {
                WorkoutId = workoutRecordPostObject.WorkoutId
            });

            if (savedWorkoutRecord == null)
            {
                return BadRequest();
            }

            var workoutRecordMapResult = Mapper.Map<WorkoutRecord, WorkoutRecordDTO>(savedWorkoutRecord);

            return workoutRecordMapResult;
        }

        [HttpGet("{workoutId}")]
        [ProducesResponseType(typeof(List<WorkoutRecordDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<WorkoutRecordDTO>>> Get([FromRoute] long workoutId)
        {
            var isActiveWorkoutExistsTask = UnitOfWork.WorkoutsRepository.IsActiveWorkoutExistsAsync(workoutId);
            var isAnyWorkoutRecordExistsTask = UnitOfWork.WorkoutRecordsRepository.IsAnyWorkoutRecordExistsAsync(workoutId);

            Task.WaitAll(isActiveWorkoutExistsTask, isAnyWorkoutRecordExistsTask);

            if (!isActiveWorkoutExistsTask.Result || !isAnyWorkoutRecordExistsTask.Result)
            {
                return BadRequest();
            }

            var workoutRecords = await UnitOfWork.WorkoutRecordsRepository.GetWorkoutRecordsByWorkoutIdAsync(workoutId);
            if (workoutRecords == null || workoutRecords.Count == 0)
            {
                return BadRequest();
            }

            var workoutRecordsMapResult = Mapper.Map<List<WorkoutRecord>, List<WorkoutRecordDTO>>(workoutRecords);
            
            return Ok(workoutRecordsMapResult);
        }
    }
}