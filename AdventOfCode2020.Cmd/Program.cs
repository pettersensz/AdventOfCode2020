using AdventOfCode2020.Cmd.Week1;
using AdventOfCode2020.Cmd.Week2;

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
      var day7TestResultPart2 = day7Test.FindHowManyBagsAShinyGoldBagContains();
      var day7Test_2 = new Day07("Day07_Input_Test_2.txt");
      var day7TestResultPart2_2 = day7Test_2.FindHowManyBagsAShinyGoldBagContains();
      Console.WriteLine("Day 7 Part 1 Test Result: " + day7TestResult);
      Console.WriteLine("Day 7 Part 2 Test Result: " + day7TestResultPart2);
      Console.WriteLine("Day 7 Part 2 Test Result 2: " + day7TestResultPart2_2);

      var day7 = new Day07("Day07_Input.txt");
      var day7Result = day7.FindHowManyBagsCanContainShinyGoldBags();
      Console.WriteLine("Day 7 Part 1 Result: " + day7Result);

      var day8Test = new Day08("Day08_Input_Test.txt");
      var day8TestResult = day8Test.RunInstructions(out _);
      var day8TestResultPart2 = day8Test.FixProgram();
      Console.WriteLine("Day 8 Part 1 Test Result: " + day8TestResult);
      Console.WriteLine("Day 8 Part 2 Test Result: " + day8TestResultPart2);

      var day8 = new Day08("Day08_Input.txt");
      var day8Result = day8.RunInstructions(out _);
      var day8ResultPart2 = day8.FixProgram();
      Console.WriteLine("Day 8 Part 1 Result: " + day8Result);
      Console.WriteLine("Day 8 Part 2 Result: " + day8ResultPart2);

      var day9Test = new Day09("Day09_Input_Test.txt");
      var day9TestResult = day9Test.FindFirstNumberNotFollowingRules(5);
      var day9TestResultPart2 = day9Test.FindEncryptionWeakness(5);
      Console.WriteLine("Day 9 Part 1 Test Result: " + day9TestResult);
      Console.WriteLine("Day 9 Part 2 Test Result: " + day9TestResultPart2);

      var day9 = new Day09("Day09_Input.txt");
      var day9Result = day9.FindFirstNumberNotFollowingRules(25);
      var day9ResultPart2 = day9.FindEncryptionWeakness(25);
      Console.WriteLine("Day 9 Part 1 Result: " + day9Result);
      Console.WriteLine("Day 9 Part 2 Result: " + day9ResultPart2);

      var day10Test = new Day10("Day10_Input_Test.txt");
      var day10TestResult = day10Test.DetermineJoltResult();
      var day10Test2 = new Day10("Day10_Input_Test_2.txt");
      var day10TestResult2 = day10Test2.DetermineJoltResult();

      var day10 = new Day10("Day10_Input.txt");
      var day10Result = day10.DetermineJoltResult();
      Console.WriteLine("Day 10 Part 1 Result: " + day10Result);
    } 
  }
}