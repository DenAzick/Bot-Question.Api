namespace Bot_Question.Api.Models;

public class ImageModel
{
    public Guid QuestionId { get; set; }
    public required IFormFile ImageFile { get; set; }
}