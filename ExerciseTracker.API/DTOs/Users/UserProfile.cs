using AutoMapper;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.API.DTOs.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(destination => destination.Id,
                    options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.FirstName,
                    options => options.MapFrom(source => source.FirstName))
                .ForMember(destination => destination.LastName,
                    options => options.MapFrom(source => source.LastName))
                .ForMember(destination => destination.Email,
                    options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.DateOfBirth,
                    options => options.MapFrom(source => source.DateOfBirth))
                .ForMember(destination => destination.Status,
                    options => options.MapFrom(source => (Data.Entities.Statuses) source.StatusId));
        }
    }
}