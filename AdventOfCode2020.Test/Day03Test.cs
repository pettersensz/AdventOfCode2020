using AdventOfCode2020.Cmd.Week1;
using FluentAssertions;

namespace AdventOfCode2020.Test
{
  public class Day03Test
  {
    private string _testFileName = "Day03_Input_Test.txt";
    private string _fileName = "Day03_Input.txt";

    [Fact]
    public void MapPointIsTreeReturnsTrueForSquare()
    {
      var result = MapPoint.IsTree('#');
      result.Should().BeTrue();
    }

    [Fact]
    public void MapPointIsTreeReturnsFalseForInvalidChar()
    {
      var result = MapPoint.IsTree('.');
      result.Should().BeFalse();
    }

    [Fact]
    public void MoveOnMapGivesExpectedResultForTestInput()
    {
      var day3 = new Day03(_testFileName);
      var result = day3.MoveOnMap(3, 1);
      result.Should().Be(7);
    }

    [Fact]
    public void MoveOnMapGivesExpectedResultForMainInput()
    {
      var day3 = new Day03(_fileName);
      var result = day3.MoveOnMap(3, 1);
      result.Should().Be(203);
    }
  }
}
