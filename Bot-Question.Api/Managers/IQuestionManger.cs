using Bot_Question.Api.Entities;
using Bot_Question.Api.Models;

namespace Bot_Question.Api.Managers;

public interface IQuestionManger
{
    QuestionModel MapToQuestionModel(Question question);
}