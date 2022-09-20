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

    public int FindHowManyBagsAShinyGoldBagContains()
    {
      //Todo Revisit
      var count = 0;
      var shinyGoldBag = _bags["shiny gold"];
      foreach(var childBag in shinyGoldBag.Children)
      {
        count += childBag.Value * FindBagsInsideRecursive(childBag.Key);
        count += childBag.Value;
      }
      return count;
    }

    private int FindBagsInsideRecursive(string key)
    {
      var count = 0;
      key = key.TrimEnd();
      var parentBag = _bags[key];
      if (parentBag.Children.Count < 1) count++;
      else
      {
        foreach (var childBag in parentBag.Children)
        {
          count += childBag.Value * FindBagsInsideRecursive(childBag.Key);
        }
      }
      return count;
    }

    public int FindHowManyBagsCanContainShinyGoldBags()
    {
      int count = 0;

      foreach (var bag in _bags)
      {
        foreach(var childBag in bag.Value.Children)
        {
          if (CheckBagChildrenRecursive(childBag.Key))
          {
            count++;
            break;
          }
        }
      }

      return count;
    }

    public bool CheckBagChildrenRecursive(string childName)
    {
      childName = childName.TrimEnd();
      if (childName == "shiny gold") return true;
      var anyChildContains = false;
      if (_bags[childName] != null)
      {
        var newChild = _bags[childName];
        foreach (var childBag in newChild.Children)
        {
          anyChildContains = CheckBagChildrenRecursive(childBag.Key);
          if (anyChildContains) return true;
        }
      }
      return anyChildContains;
    }
  }



  public class Bag
  {
    public string Color;
    public Dictionary<string, int> Children;

    public Bag(string textLine)
    {
      var firstBagIndex = textLine.IndexOf("bags");
      Color = textLine.Substring(0, firstBagIndex - 1);
      Children = new Dictionary<string, int>();
      var containEndIndex = textLine.IndexOf("contain") + 8;
      var remainingString = textLine.Substring(containEndIndex);
      if (remainingString.Contains("no other bags")) return;
      var children = remainingString.Split(',');
      foreach(var child in children)
      {
        var parts = child.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var bagIndex = Array.FindIndex(parts, p => p.Contains("bag"));
        if(int.TryParse(parts[0], out int count))
        {
          var name = "";
          for(var i = 1; i < bagIndex; i++)
          {
            name = name + parts[i] + " ";
          }
          name.TrimEnd();
          Children.Add(name, count);
        }
      }
    }
  }
}
