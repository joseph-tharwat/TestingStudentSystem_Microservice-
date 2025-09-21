using AutoMapper;
using MediatR;
using TestManagment.Domain.Entities;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure;
using TestManagment.Shared.Dtos;

namespace TestManagment.Services.CreateTest
{
    public class CreateTestService
    {
        private TestDbContext dbContext { get; }
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CreateTestService(TestDbContext _dbContext, IMapper _mapper, IMediator mediator)
        {
            dbContext = _dbContext;
            mapper = _mapper;
            this.mediator = mediator;
        }

        public async Task MakeTest(CreateTestDto createTestDto)
        {
            Test test = new Test()
            {
                Title = createTestDto.TestTitle,
                TestQuestions = new()
            };

            foreach(var id in createTestDto.questionsIds)
            {
                test.TestQuestions.Add(new TestsQuestions { TestId = test.Id, QuestionId =id});
            }

            await dbContext.AddAsync(test);
            dbContext.SaveChanges();
        }

        public async Task CreateQuestion(QuestionDto questionDto)
        {
            var question = mapper.Map<Question>(questionDto);
            await dbContext.AddAsync(question);

            var questionInfo = mapper.Map<QuestionCreatedInfo>(question);
            await mediator.Publish(new QuestionCreatedEvent(questionInfo));
            
            dbContext.SaveChanges();
        }

        public async Task CreateQuestions(List<QuestionDto> questionDtos)
        {
            var questions = mapper.Map<List<Question>>(questionDtos);
            await dbContext.AddRangeAsync(questions);

            var questionsInfo = mapper.Map<List<QuestionCreatedInfo>>(questions);
            await mediator.Publish(new QuestionsCreatedEvent(questionsInfo));

            dbContext.SaveChanges();
        }


    }
}
