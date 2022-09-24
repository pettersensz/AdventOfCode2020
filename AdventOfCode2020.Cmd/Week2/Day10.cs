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

    internal int DetermineJoltResult()
    {
      var joltSum1 = 0;
      var joltSum2 = 0;
      var joltSum3 = 0;
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
  }
}
