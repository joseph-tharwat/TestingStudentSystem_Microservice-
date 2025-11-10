using AutoMapper;
using MediatR;
using TestManagment.Domain.Entities;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.DataBase;
using TestManagment.Shared.Dtos;

namespace TestManagment.Services.CreateTest
{
    public class CreateQuestionService
    {
        private TestDbContext dbContext { get; }
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CreateQuestionService(TestDbContext _dbContext, IMapper _mapper, IMediator mediator)
        {
            dbContext = _dbContext;
            mapper = _mapper;
            this.mediator = mediator;
        }

        public async Task CreateQuestion(QuestionDto questionDto)
        {
            var question = mapper.Map<Question>(questionDto);
            await dbContext.AddAsync(question);

            var questionInfo = mapper.Map<QuestionCreatedInfo>(question);
            await mediator.Publish(new OneQuestionCreatedEvent(questionInfo));
            
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateQuestions(List<QuestionDto> questionDtos)
        {
            var questions = mapper.Map<List<Question>>(questionDtos);
            await dbContext.AddRangeAsync(questions);

            var questionsInfo = mapper.Map<List<QuestionCreatedInfo>>(questions);
            await mediator.Publish(new ManyQuestionsCreatedEvent(questionsInfo));

            await dbContext.SaveChangesAsync();
        }


    }
}
