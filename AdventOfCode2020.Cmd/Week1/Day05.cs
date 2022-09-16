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
    private int _numberOfSeats = 8;
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
          rowMax = rowMax - ((rowMax-rowMin) / 2);
        }
        if(ch == 'B')
        {
          rowMin = rowMin + ((rowMax - rowMin) / 2);
        }
        if (rowMax - rowMin == 1) row = rowMin;
        
      }
      return row;
    }

    public int FindSeatNumber(string code)
    {
      var seat = 0;
      var seatMin = 0;
      var seatMax = _numberOfSeats;
      var input = code.Substring(7, 3);
      foreach(var ch in input)
      {
        if(ch == 'L')
        {
          seatMax = seatMax - (seatMax - seatMin) / 2;
        }
        if(ch == 'R')
        {
          seatMin = seatMin + (seatMax - seatMin) / 2;
        }
        if (seatMax - seatMin == 1) seat = seatMin;
      }
      return seat;

    }

    public int FindSeatId(string code)
    {
      return _rowMultiplier * FindRowNumber(code) + FindSeatNumber(code);
    }

    public int FindHighestSeatId()
    {
      var highestId = 0;
      foreach (var line in _fileData)
      {
        var id = FindSeatId(line);
        if (id > highestId) highestId = id;
      }
      return highestId;
    }

    
  }
}
