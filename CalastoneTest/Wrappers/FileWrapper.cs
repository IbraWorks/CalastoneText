namespace CalastoneTest.Wrappers;

public class FileWrapper : IFileWrapper
{
    public async Task<string> ReadAllTextAsync(string filePath)
    {
        return await File.ReadAllTextAsync(filePath);
    }
}