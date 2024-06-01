using System.Collections;
using System.Text.Json;
using Newtonsoft.Json;

namespace MyProject.Tests;

public class ImperialBmiCalculatorTestsData : IEnumerable<object[]>
{
    private const string JSON_PATH = "Data//ImperialBmiCalculatorData.json";
    public IEnumerator<object[]> GetEnumerator()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var jsonFullPath = Path.GetRelativePath(currentDir, JSON_PATH);

        if (!File.Exists(jsonFullPath))
        {
            System.Console.WriteLine(jsonFullPath);
            throw new ArgumentException($"Couldn't find file: {jsonFullPath}");
        }

        string jsonData = File.ReadAllText(jsonFullPath);
        IEnumerable<object[]>? allCases = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);
        return allCases.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}