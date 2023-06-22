using Bot_Question.Api.Services;
using Bot_Question.Api.Models;
using Bot_Question.Api.Entities;

namespace QuizWebApi_Bot.Interfaces;

public interface IQuestionRepository
{
    Task<Guid> AddQuestionAsync(CreateQuestionModel model);
    Task<QuestionModel> AddImageAsync(ImageModel model);
    Task<Question?> GetQuestionByIdAsync(Guid questionId);
    Task<QuestionModel> UpdateQuestionAsync(Guid questionId, UpdateQuestionModel model);
    Task DeleteQuestionAsync(Guid questionId);
    Task<List<QuestionModel>> GetQuestions();
}