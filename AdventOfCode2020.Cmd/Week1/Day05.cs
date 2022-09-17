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

    public int FindSeatId(int row, int seat)
    {
      return _rowMultiplier * row + seat;
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

    public int FindIdOfYourSeat()
    {
      HashSet<string> allPossibleSeats = FindAllPossibleSeats();
      HashSet<string> occupiedSeats = FindAllOccupiedSeats();
      List<int> allOccupiedIds = FindAllOccupiedIds(occupiedSeats);
      var freeSeats = allPossibleSeats.Where(s => occupiedSeats.Contains(s) != true).ToHashSet<string>();

      var yourSeatId = 0;
      foreach (var freeSeat in freeSeats)
      {
        GetRowAndSeatInt(freeSeat, out var row, out var seat);
        var id = FindSeatId(row, seat);
        if (allOccupiedIds.Contains(id + 1) && allOccupiedIds.Contains(id - 1)) yourSeatId = id;
      }

      return yourSeatId;
    }

    private List<int> FindAllOccupiedIds(HashSet<string> occupiedSeats)
    {
      var ids = new List<int>();
      foreach(var occupiedSeat in occupiedSeats)
      {
        GetRowAndSeatInt(occupiedSeat, out var row, out var seat);
        var id = FindSeatId(row, seat);
        ids.Add(id);
      }
      return ids;
    }

    private HashSet<string> FindAllOccupiedSeats()
    {
      var occupiedSeats = new HashSet<string>();
      foreach(var line in _fileData)
      {
        var row = FindRowNumber(line);
        var seat = FindSeatNumber(line);
        occupiedSeats.Add(GetRowAndSeatString(row, seat));
      }
      return occupiedSeats;
    }

    private string GetRowAndSeatString(int row, int seat)
    {
      return $"{row}, {seat}";
    }

    private void GetRowAndSeatInt(string rowAndSeatString, out int row, out int seat)
    {
      var parts = rowAndSeatString.Split(',', StringSplitOptions.TrimEntries);
      row = int.Parse(parts[0]);
      seat = int.Parse(parts[1]);
    }

    private HashSet<string> FindAllPossibleSeats()
    {
      var allPossibleSeats = new HashSet<string>();
      for(var row = 0; row < _numberOfRows; row++)
      {
        for(var seat = 0; seat < _numberOfSeats; seat++)
        {
          allPossibleSeats.Add(GetRowAndSeatString(row, seat));
        }
      }
      return allPossibleSeats;
    }
  }
}
