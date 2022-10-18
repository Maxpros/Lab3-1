using System.Text.RegularExpressions;
class Programm
{
    public static List<string> GetLinksFromHTML(string stringHtml)
    {
        var regular = new Regex(@"<a href=""([/\w\d\.\:]+)"".*>");
        var matches = regular.Matches(stringHtml);
        GroupCollection group;
        var result = new List<string>();
        foreach (Match match in matches)
        {
            group = match.Groups;
            result.Add(group[1].Value);
        }
        return result;
    }
    public static void Main()
    {
        Console.Write("Enter local path HTML file: ");
        var localPath = Console.ReadLine();
        string path;
        if (localPath != null)
            path = Path.Combine(Environment.CurrentDirectory, localPath);
        else
            throw new Exception("null path");
        var links = GetLinksFromHTML(File.ReadAllText(path));
        foreach (var link in links)
        {
            Console.WriteLine(link);
        }
    }
}