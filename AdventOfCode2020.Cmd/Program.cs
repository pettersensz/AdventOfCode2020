using AdventOfCode2020.Cmd.Week1;

namespace AdventOfCode2020.Cmd
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var day1Test = new Day01("Day01_Input_Test.txt");
      var day1TestResult = day1Test.GetProduct(2);
      var day1TestResultPart2 = day1Test.GetProduct(3);
      Console.WriteLine("Day 1 Part 1 Test Result: " + day1TestResult);
      Console.WriteLine("Day 1 Part 2 Test Result: " + day1TestResultPart2);

      var day1 = new Day01("Day01_Input.txt");
      var day1Result = day1.GetProduct(2);
      var day1ResultPart2 = day1.GetProduct(3);
      Console.WriteLine("Day 1 Part 1 Result: " + day1Result);
      Console.WriteLine("Day 1 Part 2 Result: " + day1ResultPart2);

      var day2Test = new Day02("Day02_Input_Test.txt");
      var day2TestResult = day2Test.GetNumberOfCorrectPasswords();
      var day2TestResultPart2 = day2Test.GetNumberOfCorrectPasswordsWithDifferentPolicies();
      Console.WriteLine("Day 2 Part 1 Test Result: " + day2TestResult);
      Console.WriteLine("Day 2 Pert 2 Test Result: " + day2TestResultPart2);

      var day2 = new Day02("Day02_Input.txt");
      var day2Result = day2.GetNumberOfCorrectPasswords();
      var day2ResultPart2 = day2.GetNumberOfCorrectPasswordsWithDifferentPolicies();
      Console.WriteLine("Day 2 Part 1 Result: " + day2Result);
      Console.WriteLine("Day 2 Part 2 Result: " + day2ResultPart2);
    }
  }
}