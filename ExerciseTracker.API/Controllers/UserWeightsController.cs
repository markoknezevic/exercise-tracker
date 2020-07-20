using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.UserWeights;
using ExerciseTracker.API.Models.UserWeights;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserWeightsController : BaseController<UserWeightsController>
    {
        public UserWeightsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpPost]
        [ProducesResponseType(typeof(UserWeightDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserWeightDTO>> Post([FromBody] UserWeightPostObject userWeightPostObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isActiveUserExists = await UnitOfWork.UsersRepository.IsActiveUserExistsAsync(userWeightPostObject.UserId);
            if (!isActiveUserExists)
            {
                return BadRequest();
            }

            var savedUserWeight = await UnitOfWork.UserWeightsRepository.AddUserWeightAsync(new UserWeight()
            {
                Value = userWeightPostObject.Value,
                UserId = userWeightPostObject.UserId
            });

            if (savedUserWeight == null)
            {
                return BadRequest();
            }

            var userWeightMapResult = Mapper.Map<UserWeight, UserWeightDTO>(savedUserWeight);

            return Created(String.Empty, userWeightMapResult);
        }
        
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(List<UserWeightDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UserWeightDTO>> Get([FromRoute] long userId)
        {
            var isActiveUserExistsTask = UnitOfWork.UsersRepository.IsActiveUserExistsAsync(userId);
            var isAnyUserWeightExistsTask = UnitOfWork.UserWeightsRepository.IsAnyUserWeightExistsAsync(userId);

            Task.WaitAll(isActiveUserExistsTask, isAnyUserWeightExistsTask);
            
            if (!isActiveUserExistsTask.Result || !isAnyUserWeightExistsTask.Result)
            {
                return BadRequest();
            }

            var userWeights = await UnitOfWork.UserWeightsRepository.GetUserWeightsAsync(userId);
            if (userWeights == null || userWeights.Count == 0)
            {
                return NoContent();
            }
            
            var userWeightsMapResult = Mapper.Map<List<UserWeight>, List<UserWeightDTO>>(userWeights);

            return Ok(userWeightsMapResult);
        }
    }
}