using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class FileService
{
    public string GetFilePath(string fileName)
    {
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(directory, fileName);

        return Path.Combine(directory, fileName);
    }

    async public Task SaveToFile(string fileName, string text)
    {
        await File.WriteAllTextAsync(GetFilePath(fileName), text);
    }

    async public Task<string> ReadFromFile(string filePath)
    {
        return await File.ReadAllTextAsync(GetFilePath(filePath));
    }
}
