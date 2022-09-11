namespace AdventOfCode2020.Cmd.Week1
{
  public class Day02
  {
    public string[] _input;


    public Day02(string filename)
    {
      _input = Utils.FileReader.ReadLinesInTextFile(filename);
    }

    public List<PasswordPolicy> GetPasswordPolicies()
    {
      var policies = new List<PasswordPolicy>();
      foreach (var line in _input)
      {
        var policyString = line.Split(':')[0];
        var policy = new PasswordPolicy(policyString);
        policies.Add(policy);
      }
      return policies;
    }

    public List<DifferentPasswordPolicy> GetDifferentPasswordPolicies()
    {
      var policies = new List<DifferentPasswordPolicy>();
      foreach (var line in _input)
      {
        var policyString = line.Split(':')[0];
        var policy = new DifferentPasswordPolicy(policyString);
        policies.Add(policy);
      }
      return policies;
    }

    public List<string> GetPasswords()
    {
      var passwords = new List<string>();
      foreach (var line in _input)
      {
        var password = line.Split(": ")[1];
        passwords.Add(password);
      }
      return passwords;
    }

    public int GetNumberOfCorrectPasswords()
    {
      var policies = GetPasswordPolicies();
      var passwords = GetPasswords();
      var correctPasswords = 0;
      for (var i = 0; i < passwords.Count; i++)
      {
        var password = passwords[i];
        var policy = policies[i];
        if (!password.Contains(policy.Letter)) continue;
        var numberOfTimes = password.Count(l => l == policy.Letter);
        if (numberOfTimes < policy.MinNumber) continue;
        if (numberOfTimes > policy.MaxNumber) continue;
        correctPasswords++;

      }
      return correctPasswords;
    }

    public int GetNumberOfCorrectPasswordsWithDifferentPolicies()
    {
      var policies = GetDifferentPasswordPolicies();
      var passwords = GetPasswords();
      var correctPasswords = 0;
      for (var i = 0; i < passwords.Count; i++)
      {
        var password = passwords[i];
        var policy = policies[i];
        //Console.Write($"{password}, {policy.Letter}. ");
        if(PasswordContainsLetterAtOneOfIndexes(password, policy))
        {
          correctPasswords++;
          //Console.Write(" OK!");
        }
        //Console.Write("\n");
      }
      return correctPasswords;
    }

    public bool PasswordContainsLetterAtOneOfIndexes(string password, DifferentPasswordPolicy policy)
    {
      bool letterAtPosition1 = PasswordHasCharacterAtPosition(password, policy.Letter, policy.Position1);
      //Console.Write($"P1: {policy.Position1}: {letterAtPosition1}. ");
      bool letterAtPosition2 = PasswordHasCharacterAtPosition(password, policy.Letter, policy.Position2);
      //Console.Write($"P2: {policy.Position2}: {letterAtPosition2}. ");
      if (letterAtPosition1 && !letterAtPosition2) return true;
      if (letterAtPosition2 && !letterAtPosition1) return true;
      return false;
    }

    public bool PasswordHasCharacterAtPosition(string input, char c, int position)
    {
      if (input.Length < 1 || input == null) return false;
      var index = input.IndexOf(c);
      if (index == -1) return false;
      // Compensate for no zero-index, e.g. position 1 is first char.
      if (input[position-1] == c) return true;
      return false;
    }
  }

  public class PasswordPolicy
  {
    public int MinNumber;
    public int MaxNumber;
    public char Letter;
    public PasswordPolicy(string policy)
    {
      Letter = policy.Split(' ')[1].ToCharArray()[0];
      var numbers = policy.Split(' ')[0].Split('-');
      MinNumber = int.Parse(numbers[0]);
      MaxNumber = int.Parse(numbers[1]);
    }
  }

  public class DifferentPasswordPolicy
  {
    public int Position1;
    public int Position2;
    public char Letter;
    public DifferentPasswordPolicy(string policy)
    {
      Letter = policy.Split(' ')[1].ToCharArray()[0];
      var numbers = policy.Split(' ')[0].Split('-');
      Position1 = int.Parse(numbers[0]);
      Position2 = int.Parse(numbers[1]);
    }
  }
}
