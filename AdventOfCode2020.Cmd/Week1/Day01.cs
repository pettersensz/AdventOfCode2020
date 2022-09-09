using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Week1
{
  public class Day01
  {
    public string[] _input;
    public Day01(string filename)
    {
      _input = Utils.FileReader.ReadLinesInTextFile(filename);
    }

    public int GetProduct()
    {
      FindNumbersThatSumTo2020(out var number1, out var number2);
      return number1 * number2;
    }

    public void FindNumbersThatSumTo2020(out int number1, out int number2)
    {
      number1 = 0;
      number2 = 0;
      var numberList = GetNumberList();
      for(var i = 0; i < numberList.Count; i++)
      {
        for(var j = i+1; j < numberList.Count; j++)
        {
          var sum = numberList[i] + numberList[j];
          //Console.WriteLine($"{numberList[i]} + {numberList[j]} = {sum}");
          if(sum == 2020)
          {
            number1 = numberList[i];
            number2 = numberList[j];
          }
        }
      }

    }

    public List<int> GetNumberList()
    {
      var numbers = new List<int>();
      foreach (var line in _input)
      {
        if (int.TryParse(line, out var number))
        {
          numbers.Add(number);
        }
      }
      return numbers;
    }
  }
}
