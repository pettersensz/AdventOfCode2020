namespace AdventOfCode2020.Cmd.Week1
{
  public class Day01
  {
    public string[] _input;
    public Day01(string filename)
    {
      _input = Utils.FileReader.ReadLinesInTextFile(filename);
    }

    public int GetProduct(int howManyNumbers)
    {
      if (howManyNumbers == 2)
      {
        FindTwoNumbersThatSumTo2020(out var number1, out var number2);
        return number1 * number2;
      }

      else if (howManyNumbers == 3)
      {
        FindThreNumbersThatSumTo2020(out var n1, out var n2, out var n3);
        var product = n1 * n2 * n3;
        return product;
      }
      else
      {
        Console.WriteLine($"Input {howManyNumbers} is not supported.");
        return 0;
      }
    }

    private void FindThreNumbersThatSumTo2020(out int n1, out int n2, out int n3)
    {
      n1 = 0;
      n2 = 0;
      n3 = 0;
      var numberList = GetNumberList();
      for (var i = 0; i < numberList.Count; i++)
      {
        for (var j = i + 1; j < numberList.Count; j++)
        { 
          for(var k = j + 1; k < numberList.Count; k++)
          {
            var sum = numberList[i] + numberList[j] + numberList[k];
            if(sum == 2020)
            {
              n1 = numberList[i];
              n2 = numberList[j];
              n3 = numberList[k];
            }
          }
        }
      }
    }

    public void FindTwoNumbersThatSumTo2020(out int number1, out int number2)
    {
      number1 = 0;
      number2 = 0;
      var numberList = GetNumberList();
      for (var i = 0; i < numberList.Count; i++)
      {
        for (var j = i + 1; j < numberList.Count; j++)
        {
          var sum = numberList[i] + numberList[j];
          //Console.WriteLine($"{numberList[i]} + {numberList[j]} = {sum}");
          if (sum == 2020)
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
