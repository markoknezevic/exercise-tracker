using AutoMapper;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.API.DTOs.WorkoutRecords
{
    public class WorkoutRecordProfile : Profile
    {
        public WorkoutRecordProfile()
        {
            CreateMap<WorkoutRecord, WorkoutRecordDTO>()
                .ForMember(destination => destination.Id,
                    options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.Workout,
                    options => options.MapFrom(source => source.Workout))
                .ForMember(destination => destination.CreatedAt,
                    options => options.MapFrom(source => source.CreatedAt));
        }
    }
}