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

    public int MoveOnMap(int horizontalMove, int verticalMove)
    {
      var treeCounter = 0;
      var hPos = horizontalMove;
      for (var row = verticalMove; row < _input.Length; row = row + verticalMove)
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
