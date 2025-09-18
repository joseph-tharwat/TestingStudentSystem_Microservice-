using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestManagment.Domain.Entities;
using TestManagment.Infrastructure;
using TestManagment.Infrastructure.RabbitMQ;
using TestManagment.Shared.Dtos;

namespace TestManagment.Services.CreateTest
{
    public class CreateTestService
    {
        private TestDbContext dbContext { get; }
        private readonly IMapper mapper;
        private readonly RabbitMqService rabbitMq;

        public CreateTestService(TestDbContext _dbContext, IMapper _mapper, RabbitMqService _rabbitMq)
        {
            dbContext = _dbContext;
            mapper = _mapper;
            rabbitMq = _rabbitMq;
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

            var questionInfo = mapper.Map<QuestionInfoDto>(question);
            await rabbitMq.sendQuestionToAutoGradeServiceAsync<QuestionInfoDto>(questionInfo, "QuestionInformation");
            dbContext.SaveChanges();
        }

        public async Task CreateQuestions(List<QuestionDto> questionDtos)
        {
            var questions = mapper.Map<List<Question>>(questionDtos);
            await dbContext.AddRangeAsync(questions);

            var questionsInfo = mapper.Map<List<QuestionInfoDto>>(questions);
            await rabbitMq.sendQuestionToAutoGradeServiceAsync<List<QuestionInfoDto>>(questionsInfo, "QuestionInformation");
            dbContext.SaveChanges();
        }


    }
}
