using System.Reflection;
using Newtonsoft.Json;
using Xunit.Sdk;

namespace MyProject.Tests;

public class JsonFileData : DataAttribute
{
    private readonly string _jsonPath;
    public JsonFileData(string jsonPath)
    {
        _jsonPath = jsonPath;
    }
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

        var currentDir = Directory.GetCurrentDirectory();
        var jsonFullPath = Path.GetRelativePath(currentDir, _jsonPath);

        if (!File.Exists(jsonFullPath))
        {
            System.Console.WriteLine(jsonFullPath);
            throw new ArgumentException($"Couldn't find file: {jsonFullPath}");
        }

        string jsonData = File.ReadAllText(jsonFullPath);
        IEnumerable<object[]>? allCases = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);
        return allCases;
    }
}
