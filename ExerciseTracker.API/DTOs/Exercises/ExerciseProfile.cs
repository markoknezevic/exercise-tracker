using AutoMapper;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.API.DTOs.Exercises
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDTO>().ForMember(
                destination => destination.Name,
                options => options.MapFrom(source => source.Name))
                .ForMember(
                    destination => destination.Description,
                    options => options.MapFrom(source => source.Description));
        }
    }
}