using Bot_Question.Api.Interfaces;
using Bot_Question.Api.Managers;
using Bot_Question.Api.Repositories;
using Bot_Question.Api.Services;
using QuizWebApi_Bot.HelperServices;
using QuizWebApi_Bot.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IQuestionManger, QuestionManger>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
