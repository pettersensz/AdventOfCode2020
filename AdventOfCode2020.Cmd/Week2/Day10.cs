using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Week2
{
  public class Day10
  {
    private string[] _fileData;
    private List<int> _orderedJoltages;
    private int _deviceJoltageRating;
    private int _outletOutput;
    public Day10(string filename)
    {
      _fileData = Utils.FileReader.ReadLinesInTextFile(filename);
      var joltagesInBag = new int[_fileData.Length];
      for(var i = 0; i < _fileData.Length; i++)
      {
        joltagesInBag[i] = int.Parse(_fileData[i]);
      }
      _orderedJoltages = joltagesInBag.OrderBy(j => j).ToList();
     
      _deviceJoltageRating = joltagesInBag.Max() + 3;
      _outletOutput = 0;
    }

    internal int DetermineJoltResult(out int joltSum1, out int joltSum2, out int joltSum3)
    {
      joltSum1 = 0;
      joltSum2 = 0;
      joltSum3 = 0;
      var startJolt = _outletOutput;

      foreach(var joltageEntry in _orderedJoltages)
      {
        switch(joltageEntry - startJolt)
        {
          case 1:
            joltSum1++;
            break;
          case 2:
            joltSum2++;
            break;
          case 3:
            joltSum3++;
            break;
        }
        startJolt = joltageEntry;
      }
      // Finally, your device's built-in adapter is always 3 higher than the highest adapter
      joltSum3++;

      return joltSum1 * joltSum3;
    }

    public int DeterminePossibleCombinations()
    {
      var joltResult = DetermineJoltResult(out var joltSum1, out var joltSum2, out var joltSum3);
      var diff = _deviceJoltageRating;
      var threesOnly = joltSum3 * 3;
      var twosOnly = joltSum2 * 2;
      var onesOnly = joltSum1;



      // For test data 1 we expect 8
      return 0;
    }
  }
}
