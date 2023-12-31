﻿using Microsoft.AspNetCore.Mvc;
using Bot_Question.Api.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using QuizWebApi_Bot.Interfaces;

namespace Bot_Question.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionController(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    [HttpPost("bot")]
    public async Task<IActionResult> PostUpdate([FromBody] Update update)
    {
        var bot = new TelegramBotClient("6197639222:AAHXFiuLkmu0fg131tOM5w4TuSnW2PfbrT4");

        if (update is { Type: Telegram.Bot.Types.Enums.UpdateType.Message, Message.From: not null })
        {
            await bot.SendTextMessageAsync(update.Message.From.Id, "message");
        }

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddQuestionAsync(CreateQuestionModel model)
    {
        var question = await _questionRepository.AddQuestionAsync(model);
        return Ok(question);
    }

    [HttpPost("image")]
    public async Task<IActionResult> AddImagesAsync([FromForm] ImageModel model)
    {
        var questionModel = await _questionRepository.AddImageAsync(model);
        return Ok(questionModel);
    }

    [HttpPut("{questionId}")]
    public async Task<IActionResult> UpdateQuestionAsync(Guid questionId, UpdateQuestionModel model)
    {
        return Ok(await _questionRepository.UpdateQuestionAsync(questionId, model));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        return Ok(await _questionRepository.GetQuestions());
    }

    [HttpGet("{questionId}")]
    public async Task<IActionResult> GetQuestionByIdAsync(Guid questionId)
    {
        return Ok(await _questionRepository.GetQuestionByIdAsync(questionId));
    }

    [HttpDelete("{questionId}")]
    public async Task<IActionResult> DeleteQuestionAsync(Guid questionId)
    {
        await _questionRepository.DeleteQuestionAsync(questionId);
        return Ok();
    }
}