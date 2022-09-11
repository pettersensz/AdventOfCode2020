using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Week1
{
  public class Day03
  {
    public string[] _input;

    public Day03(string filename, int mapRepetitions)
    {
      _input = Utils.FileReader.ReadLinesInTextFile(filename);
      for(var row = 0; row < _input.Length; row++)
      {
        var line = _input[row];
        var newLine = "";
        for(var repetition = 0; repetition < mapRepetitions; repetition++)
        {
          newLine = newLine + line;
        }
        _input[row] = newLine;
      }
    }

    public int MoveOnMap(int horizontalMove, int verticalMove)
    {
      var treeCounter = 0;
      var hPos = horizontalMove;
      for(var row = verticalMove; row < _input.Length; row = row + verticalMove)
      {
          var value = _input[row][hPos];
          if (MapPoint.IsTree(value))
          {
            treeCounter++;
            Console.WriteLine($"Found tree at {hPos}, {row}");
          }
        hPos = hPos + horizontalMove;
      }

      return treeCounter;
    }
  }

  public static class MapPoint
  {
    public static bool IsTree(char input)
    {
      if (input == '#') return true;
      return false;
    }
  }
}
