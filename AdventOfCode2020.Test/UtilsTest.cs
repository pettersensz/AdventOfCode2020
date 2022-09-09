using AdventOfCode2020.Cmd.Utils;
using FluentAssertions;

namespace AdventOfCode2020.Test
{
  public class UtilsTest
  {
    [Fact]
    public void CanReadDataFromDay01TestFile()
    {
      var expectedResult = new string[]
      {
        "1721",
        "979",
        "366",
        "299",
        "675",
        "1456"
      };
      var fileName = "Day01_Input_Test.txt";

      var actualResult = FileReader.ReadLinesInTextFile(fileName);

      actualResult.Should().Equal(expectedResult);
    }
  }
}
