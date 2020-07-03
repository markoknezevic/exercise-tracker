using AutoMapper;
using ExerciseTracker.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    public class BaseController<TController> : ControllerBase where TController : ControllerBase
    {
        protected IMapper Mapper;

        protected IUnitOfWork UnitOfWork;

        protected BaseController(IMapper mapper, IUnitOfWork unitOfWork) : base()
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}