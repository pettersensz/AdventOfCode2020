namespace AdventOfCode2020.Cmd.Week1
{
  public class Day03
  {
    public string[] _input;

    public Day03(string filename)
    {
      _input = Utils.FileReader.ReadLinesInTextFile(filename);
    }


    private void ExtendLines()
    {
      for (var row = 0; row < _input.Length; row++)
      {
        var line = _input[row];
        var newLine = "";
        for (var repetition = 0; repetition < 10; repetition++)
        {
          newLine = newLine + line;
        }
        _input[row] = newLine;
      }
    }

    public long MoveOnMap(List<MapMove> moves)
    {
      long product = 1;
      foreach (var move in moves)
      {
        product *= MoveOnMap(move);
      }
      return product;
    }

    public int MoveOnMap(MapMove move)
    {
      var treeCounter = 0;
      var hPos = move.Right;
      for (var row = move.Down; row < _input.Length; row += move.Down)
      {
        char value = 'A';
        while(value == 'A')
        {
          try
          {
            value = _input[row][hPos];
          }
          catch (IndexOutOfRangeException)
          {
            ExtendLines();
          }
        }
        if (MapPoint.IsTree(value))
        {
          treeCounter++;
          //Console.WriteLine($"Found tree at {hPos}, {row}");
        }
        hPos += move.Right;
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

  public class MapMove
  {
    public int Down;
    public int Right;
    public MapMove(int down, int right)
    {
      Down = down;
      Right = right;
    }
  }
}
