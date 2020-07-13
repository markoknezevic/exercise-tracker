using AutoMapper;
using ExerciseTracker.API.Models.ExerciseWorkouts;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.API.DTOs.ExerciseWorkouts
{
    public class ExerciseWorkoutProfile : Profile
    {
        public ExerciseWorkoutProfile()
        {
            CreateMap<ExerciseWorkout, ExerciseWorkoutDTO>()
                .ForMember(destination => destination.SeriesNumber,
                    options => options.MapFrom(source => source.SeriesNumber))
                .ForMember(destination => destination.Repeats,
                    options => options.MapFrom(source => source.Repeats))
                .ForMember(destination => destination.WeightValue,
                    options => options.MapFrom(source => source.WeightValue))
                .ForMember(destination => destination.Status,
                    options => options.MapFrom(source => (Data.Entities.Statuses) source.StatusId))
                .ForMember(destination => destination.Exercise,
                    options => options.MapFrom(source => source.Exercise));

            CreateMap<ExerciseWorkoutPostObject, ExerciseWorkout>()
                .ForMember(destination => destination.SeriesNumber,
                    options => options.MapFrom(source => source.SeriesNumber))
                .ForMember(destination => destination.Repeats,
                    options => options.MapFrom(source => source.Repeats))
                .ForMember(destination => destination.WeightValue,
                    options => options.MapFrom(source => source.WeightValue))
                .ForMember(destination => destination.WorkoutId,
                    options => options.MapFrom(source => source.WorkoutId))
                .ForMember(destination => destination.ExerciseId,
                    options => options.MapFrom(source => source.ExerciseId))
                .ForMember(destination => destination.StatusId,
                    options => options.MapFrom(source => (short) Data.Entities.Statuses.Active));

        }
    }
}