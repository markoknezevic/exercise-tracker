using AutoMapper;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.API.DTOs.UserWeights
{
    public class UserWeightProfile : Profile
    {
        public UserWeightProfile()
        {
            CreateMap<UserWeight, UserWeightDTO>()
                .ForMember(destination => destination.Id,
                    options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .ForMember(destination => destination.UserId,
                    options => options.MapFrom(source => source.UserId));
        }
    }
}