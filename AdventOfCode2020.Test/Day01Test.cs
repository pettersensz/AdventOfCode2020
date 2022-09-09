using AdventOfCode2020.Cmd.Week1;
using FluentAssertions;

namespace AdventOfCode2020.Test
{
  public class Day01Test
  {
    private string _testFileName = "Day01_Input_Test.txt";

    [Fact]
    public void GetNumberListReturnsCorrectNumbersForTestInput()
    {
      var day1 = new Day01(_testFileName);
      var numberList = day1.GetNumberList();

      numberList.Should().NotBeNullOrEmpty();
      numberList.Count.Should().Be(6,"List should have six entries");
      numberList.Should().Contain(979);
      numberList.Max().Should().Be(1721);
      numberList.Min().Should().Be(299);
      numberList.Should().NotContain(300);
    }

    [Fact]
    public void FindNumbersReturnsCorrectNumbersForTestInput()
    {
      var day1 = new Day01(_testFileName);
      day1.FindNumbersThatSumTo2020(out var number1, out var number2);
      var sum = number1 + number2;
      sum.Should().Be(2020);
      number1.Should().Be(1721);
      number2.Should().Be(299);
    }

    [Fact]
    public void GetProductReturnsCorrectNumberForTestInput()
    {
      var day1 = new Day01(_testFileName);
      var result = day1.GetProduct();
      result.Should().Be(514579);
    }
  }
}