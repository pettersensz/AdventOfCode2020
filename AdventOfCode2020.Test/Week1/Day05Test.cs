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

      var row2 = day5.FindRowNumber(testData[1]);
      var seat2 = day5.FindSeatNumber(testData[1]);
      var id2 = day5.FindSeatId(testData[1]);
      row2.Should().Be(70);
      seat2.Should().Be(7);
      id2.Should().Be(567);

      var row3 = day5.FindRowNumber(testData[2]);
      var seat3 = day5.FindSeatNumber(testData[2]);
      var id3 = day5.FindSeatId(testData[2]);
      row3.Should().Be(14);
      seat3.Should().Be(7);
      id3.Should().Be(119);

      var row4 = day5.FindRowNumber(testData[3]);
      var seat4 = day5.FindSeatNumber(testData[3]);
      var id4 = day5.FindSeatId(testData[3]);
      row4.Should().Be(102);
      seat4.Should().Be(4);
      id4.Should().Be(820);
    }
  }
}
