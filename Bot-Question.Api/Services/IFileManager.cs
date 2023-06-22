namespace Bot_Question.Api.Interfaces;

public interface IFileManager
{
    Task<string> SaveFileToWwwrootAsync(IFormFile logoFile, string folderName);
}