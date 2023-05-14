namespace CalastoneTest.Wrappers;

public interface IFileWrapper
{
    Task<string> ReadAllTextAsync(string filePath);
}