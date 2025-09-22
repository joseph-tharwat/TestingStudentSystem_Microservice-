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

            CreateMap<CreateTestDto, Test>()
                .ForMember(dist=>dist.Title,opt=>opt.MapFrom(src=>src.TestTitle))
                .ForMember(dist=>dist.TestQuestions, opt=>opt.MapFrom(src=>
                    src.questionsIds
                    .Distinct()
                    .Select(id=> new TestQuestion() { QuestionId= id})
                    ));
        }
    }
}
