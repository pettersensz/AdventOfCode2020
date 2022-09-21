using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      for(var i = preambleLength; i < _fileData.Length; i++)
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
      for(var j = index - preambleLength; j < index; j++)
      {
        var diff = sum - int.Parse(_fileData[j]);
        if(subSet.Contains(diff)) return true;
      }
      return false;
    }
  }
}
