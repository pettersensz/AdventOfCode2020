namespace AdventOfCode2020.Cmd.Week2
{
  public class Day09
  {
    private string[] _fileData;
    public Day09(string filename)
    {
      _fileData = Utils.FileReader.ReadLinesInTextFile(filename);
    }

    public int FindFirstNumberNotFollowingRules(int preambleLength)
    {
      for (var i = preambleLength; i < _fileData.Length; i++)
      {
        bool ok = CheckRuleForOneIndex(i, preambleLength);
        if (!ok)
        {
          var faultyIndex = i;
          return int.Parse(_fileData[i]);
        }
      }
      return 0;
    }

    private bool CheckRuleForOneIndex(int index, int preambleLength)
    {
      var sum = int.Parse(_fileData[index]);
      var subSet = _fileData.Skip(index - preambleLength).Take(preambleLength).Select(s => int.Parse(s)).ToArray();
      for (var j = index - preambleLength; j < index; j++)
      {
        var diff = sum - int.Parse(_fileData[j]);
        if (subSet.Contains(diff)) return true;
      }
      return false;
    }

    internal int FindEncryptionWeakness(int preambleLength)
    {
      var invalidNumber = FindFirstNumberNotFollowingRules(preambleLength);
      var sum = 0;
      var start = 0;
      var end = 0;
      var foundIt = false;
      for (var startIndex = 0; startIndex < _fileData.Length; startIndex++)
      {
        var valueAtIndex = int.Parse(_fileData[startIndex]);
        sum += valueAtIndex;
        for (var endIndex = startIndex + 1; endIndex < _fileData.Length; endIndex++)
        {
          sum += int.Parse(_fileData[endIndex]);
          if (sum == invalidNumber)
          {
            foundIt = true;
            start = startIndex;
            end = endIndex;
            break;
          }
          if (sum > invalidNumber) break;
        }
        if (foundIt) break;
        sum = 0;
      }
      var subSet = _fileData.Skip(start).Take(end-start+1).Select(s => int.Parse(s)).ToArray();
      var min = subSet.Min();
      var max = subSet.Max();
      return min + max;
    }
  }
}
