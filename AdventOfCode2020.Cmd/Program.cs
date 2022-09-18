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
      Console.WriteLine("Day 2 Part 2 Test Result: " + day2TestResultPart2);

      var day2 = new Day02("Day02_Input.txt");
      var day2Result = day2.GetNumberOfCorrectPasswords();
      var day2ResultPart2 = day2.GetNumberOfCorrectPasswordsWithDifferentPolicies();
      Console.WriteLine("Day 2 Part 1 Result: " + day2Result);
      Console.WriteLine("Day 2 Part 2 Result: " + day2ResultPart2);

      var day3Test = new Day03("Day03_Input_Test.txt");
      var initialMove = new MapMove(1, 3);
      var allMoves = new List<MapMove>();
      allMoves.Add(new MapMove(1, 1));
      allMoves.Add(new MapMove(1, 3));
      allMoves.Add(new MapMove(1, 5));
      allMoves.Add(new MapMove(1, 7));
      allMoves.Add(new MapMove(2, 1));
      var day3TestResult = day3Test.MoveOnMap(initialMove);
      var day3TestResultPart2 = day3Test.MoveOnMap(allMoves);
      Console.WriteLine("Day 3 Part 1 Test Result: " + day3TestResult);
      Console.WriteLine("Day 3 Part 2 Test Result: " + day3TestResultPart2);

      var day3 = new Day03("Day03_Input.txt");
      var day3Result = day3.MoveOnMap(initialMove);
      var day3ResultPart2 = day3.MoveOnMap(allMoves);
      Console.WriteLine("Day 3 Part 1 Result: " + day3Result);
      Console.WriteLine("Day 3 Part 2 Result: " + day3ResultPart2);

      var day4Test = new Day04("Day04_Input_Test.txt");
      var day4TestResult = day4Test.HowManyValidPassports(false);
      Console.WriteLine("Day 4 Part 1 Test Result: " + day4TestResult);

      var day4 = new Day04("Day04_Input.txt");
      var day4Result = day4.HowManyValidPassports(false);
      var day4ResultPart2 = day4.HowManyValidPassports(true);
      Console.WriteLine("Day 4 Part 1 Result: " + day4Result);
      Console.WriteLine("Day 4 Part 2 Result: " + day4ResultPart2);

      var day5 = new Day05("Day05_Input.txt");
      var day5Result = day5.FindHighestSeatId();
      var day5ResultPart2 = day5.FindIdOfYourSeat();
      Console.WriteLine("Day 5 Part 1 Result: " + day5Result);
      Console.WriteLine("Day 5 Part 2 Result: " + day5ResultPart2);

      var day6Test = new Day06("Day06_Input_Test.txt");
      var day6TestResult = day6Test.FindSumOfUniqueAnswers();
      var day6TestResultPart2 = day6Test.FindSumOfCommonAnswers();
      Console.WriteLine("Day 6 Part 1 Test Result: " + day6TestResult);
      Console.WriteLine("Day 6 Part 2 Test Result: " + day6TestResultPart2);

      var day6 = new Day06("Day06_Input.txt");
      var day6Result = day6.FindSumOfUniqueAnswers();
      var day6ResultPart2 = day6.FindSumOfCommonAnswers();
      Console.WriteLine("Day 6 Part 1 Result: " + day6Result);
      Console.WriteLine("Day 6 Part 2 Resutl: " + day6ResultPart2);

      var day7Test = new Day07("Day07_Input_Test.txt");
      var day7TestResult = day7Test.FindHowManyBagsCanContainShinyGoldBags();

      Console.WriteLine("Day 7 Part 1 Test Result: " + day7TestResult);

      var day7 = new Day07("Day07_Input.txt");
      var day7Result = day7.FindHowManyBagsCanContainShinyGoldBags();
      Console.WriteLine("Day 7 Part 1 Result: " + day7Result);
    } 
  }
}