using AdventOfCode2020.Cmd.Week1;
using FluentAssertions;

namespace AdventOfCode2020.Test.Week1
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

        [Fact]
        public void PositionContainsCharacterReturnsTrueAtCorrectIndex()
        {
            var day2 = new Day02(_testFileName);
            var result = day2.PasswordHasCharacterAtPosition("abcde", 'a', 1);
            result.Should().BeTrue("String has 'a' at position 1.");
        }

        [Fact]
        public void PositionContainsCharacterReturnsFalseAtWrongIndex()
        {
            var day2 = new Day02(_testFileName);
            var result = day2.PasswordHasCharacterAtPosition("abcde", 'a', 3);
            result.Should().BeFalse("String does not have 'a' at position 3.");
        }


        [Fact]
        public void PositionContainsCharacterReturnsFalseIfStringDoesNotContainCharacter()
        {
            var day2 = new Day02(_testFileName);
            var result2 = day2.PasswordHasCharacterAtPosition("cdefg", 'b', 1);
            result2.Should().BeFalse("String does not contain 'b'.");
        }

        [Fact]
        public void TestExamplePasswordsWithDifferentPolicy()
        {
            var day2 = new Day02(_testFileName);

            var password1 = "abcde";
            var policy1 = new DifferentPasswordPolicy("1-3 a");
            var result1 = day2.PasswordContainsLetterAtOneOfIndexes(password1, policy1);
            result1.Should().BeTrue("Password contains 'a' at position 1, but not 3");

            var password2 = "cdefg";
            var policy2 = new DifferentPasswordPolicy("1-3 b");
            var result2 = day2.PasswordContainsLetterAtOneOfIndexes(password2, policy2);
            result2.Should().BeFalse("Password does not contain expected character");

            var password3 = "ccccccccc";
            var policy3 = new DifferentPasswordPolicy("2-9 c");
            var result3 = day2.PasswordContainsLetterAtOneOfIndexes(password3, policy3);
            result3.Should().BeFalse("Both positions contain the letter c");

            var password4 = "tjjj";
            var policy4 = new DifferentPasswordPolicy("3-4 j");
            var result4 = day2.PasswordContainsLetterAtOneOfIndexes(password4, policy4);
            result4.Should().BeFalse("Both positions contain the letter j");
        }
    }
}
