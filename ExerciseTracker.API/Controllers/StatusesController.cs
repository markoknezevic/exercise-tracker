using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseTracker.API.DTOs.Statuses;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ExerciseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : BaseController<StatusesController>
    {
        public StatusesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet]
        [ProducesResponseType(typeof(List<StatusDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        public ActionResult<List<StatusDTO>> Get()
        {
            var statuses = UnitOfWork.StatusesRepository.GetAllStatuses();
            if (statuses == null || !statuses.Any())
            {
                return NoContent();
            }
            
            var statusesMapReuslt = Mapper.Map<List<Status>, List<StatusDTO>>(statuses);

            return Ok(statusesMapReuslt);    
        }
    }
}