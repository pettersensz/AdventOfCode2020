using AdventOfCode2020.Cmd.Week1;
using FluentAssertions;

namespace AdventOfCode2020.Test
{
  public class Day02Test
  {
    private string _testFileName = "Day02_Input_Test.txt";

    [Fact]
    public void TestDataGivesCorrectPolicies()
    {
      var day2 = new Day02(_testFileName);
      var policies = day2.GetPasswordPolicies();

      policies.Count.Should().Be(3);

      policies[0].MinNumber.Should().Be(1);
      policies[0].MaxNumber.Should().Be(3);
      policies[0].Letter.Should().Be('a');

      policies[1].MinNumber.Should().Be(1);
      policies[1].MaxNumber.Should().Be(3);
      policies[1].Letter.Should().Be('b');

      policies[2].MinNumber.Should().Be(2);
      policies[2].MaxNumber.Should().Be(9);
      policies[2].Letter.Should().Be('c');
    }

    [Fact]
    public void TestDataGivesCorrectDifferentPolicies()
    {
      var day2 = new Day02(_testFileName);
      var policies = day2.GetDifferentPasswordPolicies();

      policies.Count.Should().Be(3);

      policies[0].Position1.Should().Be(1);
      policies[0].Position2.Should().Be(3);
      policies[0].Letter.Should().Be('a');

      policies[1].Position1.Should().Be(1);
      policies[1].Position2.Should().Be(3);
      policies[1].Letter.Should().Be('b');

      policies[2].Position1.Should().Be(2);
      policies[2].Position2.Should().Be(9);
      policies[2].Letter.Should().Be('c');
    }

    [Fact]
    public void TestDataGivesCorrectPasswords()
    {
      var day2 = new Day02(_testFileName);
      var passwords = day2.GetPasswords();

      passwords.Count.Should().Be(3);

      passwords[0].Should().Be("abcde");
      passwords[1].Should().Be("cdefg");
      passwords[2].Should().Be("ccccccccc");
    }

    [Fact]
    public void TestDataGivesCorrectNumberOfValidPasswords()
    {
      var day2 = new Day02(_testFileName);
      int correctPasswords = day2.GetNumberOfCorrectPasswords();

      correctPasswords.Should().Be(2);
    }

    [Fact]
    public void TestDataGivesCorrectNumberOfValidPasswordsForDifferentPolicies()
    {
      var day2 = new Day02(_testFileName);
      int correctPasswords = day2.GetNumberOfCorrectPasswordsWithDifferentPolicies();

      correctPasswords.Should().Be(1);
    }
  }
}
