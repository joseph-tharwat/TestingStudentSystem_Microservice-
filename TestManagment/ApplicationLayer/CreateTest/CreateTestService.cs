using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var validQuestionIds = await dbContext.Questions
                .Where(q => createTestDto.questionsIds.Contains(q.Id))
                .Select(q => q.Id)
                .ToListAsync();

            var invalidIds = createTestDto.questionsIds.Except(validQuestionIds).ToList();
            if(invalidIds.Count!=0)
            {
                throw new ArgumentException($"Invalid question ids {string.Join(",",invalidIds)}");
            }

            var test = mapper.Map<Test>(createTestDto);

            await dbContext.AddAsync(test);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddQuestionToTest(ModifyTestRequest modifyTestRequest)
        {
            if(modifyTestRequest.testId == 0)
            {
                throw new ArgumentException("Invalid test id");
            }
            if (modifyTestRequest.questionId == 0)
            {
                throw new ArgumentException("Invalid question id");
            }

            var test = await dbContext.Tests.Where(t => t.Id == modifyTestRequest.testId).Include(t=>t.TestQuestions).FirstOrDefaultAsync();
            if(test == null)
            {
                throw new ArgumentException("This test is not created");
            }

            test.AddQuestion(modifyTestRequest.questionId);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveQuestionToTest(ModifyTestRequest modifyTestRequest)
        {
            if (modifyTestRequest.testId == 0)
            {
                throw new ArgumentException("Invalid test id");
            }
            if (modifyTestRequest.questionId == 0)
            {
                throw new ArgumentException("Invalid question id");
            }

            var test = await dbContext.Tests.Where(t => t.Id == modifyTestRequest.testId).Include(t => t.TestQuestions).FirstOrDefaultAsync();
            if (test == null)
            {
                throw new ArgumentException("This test is not created");
            }

            test.RemoveQuestion(modifyTestRequest.questionId);
            await dbContext.SaveChangesAsync();
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
