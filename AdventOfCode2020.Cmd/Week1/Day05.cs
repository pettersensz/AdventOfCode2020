using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Week1
{
  public class Day05
  {
    private string[] _fileData;
    private int _rowMultiplier = 8;
    private int _numberOfRows = 128;
   public Day05(string filename)
    {
      _fileData = Utils.FileReader.ReadLinesInTextFile(filename);
    }

    public int FindRowNumber(string code)
    {
      var row = 0;
      var rowMin = 0;
      var rowMax = _numberOfRows;
      var input = code.Substring(0, 7);
      foreach(var ch in input)
      {
        if(ch == 'F')
        {
          rowMax = rowMax / 2;
        }
        if(ch == 'B')
        {
          rowMin = ?
        }
      }
      return row;
    }

    public int FindSeatNumber(string code)
    {
      return 0;
    }

    public int FindSeatId(string code)
    {
      return _rowMultiplier * FindRowNumber(code) + FindSeatNumber(code);
    }
  }
}
