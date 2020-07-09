using AutoMapper;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.API.DTOs.Workouts
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutDTO>()
                .ForMember(destination => destination.Id,
                    options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name,
                    options => options.MapFrom(source => source.Name))
                .ForMember(destination => destination.Description,
                    options => options.MapFrom(source => source.Description))
                .ForMember(destination => destination.Status,
                    options => options.MapFrom(source => (Data.Entities.Statuses) source.StatusId))
                .ForMember(destination => destination.UserId,
                    options => options.MapFrom(source => source.UserId));
        }
        }
}
