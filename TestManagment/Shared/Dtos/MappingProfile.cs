using AutoMapper;
using TestManagment.Domain.Entities;

namespace TestManagment.Shared.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<QuestionDto, Question>();
            CreateMap<Question,QuestionInfoDto>();
        }
    }
}
