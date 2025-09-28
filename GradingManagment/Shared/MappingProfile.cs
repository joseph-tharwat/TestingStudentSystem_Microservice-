using AutoMapper;
using GradingManagment.Domain.Entities;

namespace GradingManagment.Shared
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<QuestionCreatedInfo, QuestionInformation>()
                .ForMember(dist=> dist.QuestionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dist=>dist.Answer, opt=> opt.MapFrom(src=>src.Answer));
        }
    }
}
