using Bot_Question.Api.Entities;
using Bot_Question.Api.Managers;
using Bot_Question.Api.Models;

namespace QuizWebApi_Bot.HelperServices;

public class QuestionManger : IQuestionManger
{
    public QuestionModel MapToQuestionModel(Question question)
    {
        return new QuestionModel
        {
            Id = question.Id,
            QuestionText = question.QuestionText,
            Description = question.Description,
            Choices = question.Choices,
            CorrectAnswer = question.CorrectAnswer,
            ImagePath = question.ImagePath
        };
    }

    
}