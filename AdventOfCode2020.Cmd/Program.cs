using AdventOfCode2020.Cmd.Week1;

namespace AdventOfCode2020.Cmd
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var day1Test = new Day01("Day01_Input_Test.txt");
      var testResult = day1Test.GetProduct();
      Console.WriteLine("Day 1 Test Result: " + testResult);

      var day1 = new Day01("Day01_Input.txt");
      var result = day1.GetProduct();
      Console.WriteLine("Day 1 Result: " + result);
    }
  }
}