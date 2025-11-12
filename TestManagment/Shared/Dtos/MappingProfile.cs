using AutoMapper;
using TestManagment.Domain.Entities;
using TestManagment.Domain.Events;
using TestManagment.Domain.ValueObjects.Question;
using TestManagment.Domain.ValueObjects.Test;

namespace TestManagment.Shared.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<QuestionDto, Question>();

            CreateMap<QuestionAnswer, string>()
                .ConvertUsing(src => src.Value);

            CreateMap<Question,QuestionCreatedInfo>();

            CreateMap<CreateTestDto, Test>()
                .ForMember(dist=>dist.Title, opt=>opt.MapFrom(src=>src.TestTitle))
                .ForMember(dist=>dist.TestQuestions, opt=>opt.MapFrom(src=>
                    src.questionsIds
                    .Distinct()
                    .Select(id=> new TestQuestion() { QuestionId= id})
                    ));

            CreateMap<Question, NextQuestion>()
                .ForCtorParam(nameof(NextQuestion.QuestionIndex), opt => opt.MapFrom(src => 0))
                .ForCtorParam(nameof(NextQuestion.QuestionId), opt => opt.MapFrom(src => src.Id))
                .ForCtorParam(nameof(NextQuestion.QuestionText), opt => opt.MapFrom(src => src.QuestionText.Value))
                .ForCtorParam(nameof(NextQuestion.Choise1), opt => opt.MapFrom(src => src.Choise1.Value))
                .ForCtorParam(nameof(NextQuestion.Choise2), opt => opt.MapFrom(src => src.Choise2.Value))
                .ForCtorParam(nameof(NextQuestion.Choise3), opt => opt.MapFrom(src => src.Choise3.Value));
        }
    }
}
