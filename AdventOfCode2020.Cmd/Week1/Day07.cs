using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Week1
{
  public class Day07
  {
    private string[] _fileData;
    private Dictionary<string, Bag> _bags;
    public Day07(string filename)
    {
      _fileData = Utils.FileReader.ReadLinesInTextFile(filename);
      _bags = new Dictionary<string, Bag>();
      foreach (string line in _fileData)
      {
        var bag = new Bag(line);
        _bags.Add(bag.Color, bag);
      }
    }
  }

  public class Bag
  {
    public string Color;

    public Bag(string textLine)
    {
      var firstBagIndex = textLine.IndexOf("bags");
      Color = textLine.Substring(0, firstBagIndex - 1);
    }
  }
}
