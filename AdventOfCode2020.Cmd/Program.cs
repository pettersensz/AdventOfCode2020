using AdventOfCode2020.Cmd.Week1;

namespace AdventOfCode2020.Cmd
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var day1Test = new Day01("Day01_Input_Test.txt");
      var testResult = day1Test.GetProduct(2);
      var testResultPart2 = day1Test.GetProduct(3);
      Console.WriteLine("Day 1 Part 1 Test Result: " + testResult);
      Console.WriteLine("Day 1 Pert 2 Test Result: " + testResultPart2);

      var day1 = new Day01("Day01_Input.txt");
      var result = day1.GetProduct(2);
      var part2Result = day1.GetProduct(3);
      Console.WriteLine("Day 1 Part 1 Result: " + result);
      Console.WriteLine("Day 1 Part 2 Result: " + part2Result);
    }
  }
}