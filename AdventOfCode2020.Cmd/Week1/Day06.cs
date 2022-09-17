namespace AdventOfCode2020.Cmd.Week1
{
  public class Day06
  {
    private string[] _fileData;
    private List<Group> _groups;
    public Day06(string filename)
    {
      _fileData = Utils.FileReader.ReadLinesInTextFile(filename);
      _groups = new List<Group>();
      var answers = new List<string>();
      foreach (string line in _fileData)
      {
        if (line.Length > 0)
        {
          answers.Add(line);
        }
        else
        {
          var group = new Group(answers);
          _groups.Add(group);
          answers = new List<string>();
        }
      }
      // Add last entry
      var lastGroup = new Group(answers);
      _groups.Add(lastGroup);
    }

    public int FindSumOfCommonAnswers()
    {
      var sum = 0;
      foreach(var group in _groups)
      {
        int commonAnswers = group.FindCommonAnswers();
        sum += commonAnswers;
      }
      return sum;
    }

    public int FindSumOfUniqueAnswers()
    {
      var sum = 0;
      foreach(var group in _groups)
      {
        int uniqueAnswers = group.FindUniqueAnswers();
        sum += uniqueAnswers;
      }
      return sum;
    }

  }

  public class Group
  {
    public List<string> Answers;
    public Group(List<string> answers)
    {
      Answers = answers;
    }

    internal int FindCommonAnswers()
    {
      var uniqueAnswers = GetListOfUniqueAnswers();
      List<char> commonAnswers = new List<char>();
      foreach(var uniqueAnswer in uniqueAnswers)
      {
        var ok = true;
        foreach(var answer in Answers)
        {
          if (answer.Contains(uniqueAnswer)) continue;
          ok = false;
        }
        if (ok) commonAnswers.Add(uniqueAnswer);
      }
      return commonAnswers.Count;
    }

    internal int FindUniqueAnswers()
    {
      var uniqueAnswers = GetListOfUniqueAnswers();
      return uniqueAnswers.Count;
    }

    private List<char> GetListOfUniqueAnswers()
    {
      var uniqueAnswers = new List<char>();
      foreach (var line in Answers)
      {
        var characters = line.ToCharArray();
        foreach (char c in characters)
        {
          if (c == ' ') continue;
          if (!uniqueAnswers.Contains(c))
          {
            uniqueAnswers.Add(c);
          }
        }
      }
      return uniqueAnswers;
    }
  }
}
