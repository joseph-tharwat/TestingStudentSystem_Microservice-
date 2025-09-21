using AutoMapper;
using TestManagment.Domain.Entities;
using TestManagment.Domain.Events;

namespace TestManagment.Shared.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<QuestionDto, Question>();
            CreateMap<Question,QuestionCreatedInfo>();
        }
    }
}
