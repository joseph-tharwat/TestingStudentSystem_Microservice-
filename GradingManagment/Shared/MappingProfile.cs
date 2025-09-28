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

            CreateMap<StudentAnswer, StudentGrade>()
                .ForMember(dist => dist.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dist=>dist.QuestionId, opt=>opt.MapFrom(src=>src.QuestionId))
                .ForMember(dist=>dist.TestId, opt=>opt.MapFrom(src=>src.TestId))
                .ForMember(dist=>dist.StudentAnswer, opt=>opt.MapFrom(src=>src.Answer))
                .ForMember(dist=>dist.Grade, opt=>opt.MapFrom(scr=> 1));
        }
    }
}
