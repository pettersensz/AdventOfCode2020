using AdventOfCode2020.Cmd.Week1;
using AdventOfCode2020.Cmd.Utils;
using FluentAssertions;


namespace AdventOfCode2020.Test.Week1
{
  public class Day05Test
  {
    private string _testFileName = "Day05_Input_Test.txt";
    [Fact]
    public void FindRowNumberTest()
    {
      var testData = FileReader.ReadLinesInTextFile(_testFileName);
      testData.Length.Should().Be(4);
      var day5 = new Day05(_testFileName);

      var row1 = day5.FindRowNumber(testData[0]);
      var seat1 = day5.FindSeatNumber(testData[0]);
      var id1 = day5.FindSeatId(testData[0]);
      row1.Should().Be(44);
      seat1.Should().Be(5);
      id1.Should().Be(357);
    }
  }
}
