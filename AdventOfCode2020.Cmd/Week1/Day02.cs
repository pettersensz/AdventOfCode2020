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
        if (!password.Contains(policy.Letter)) continue;
        if (password[policy.Position1+1] == policy.Letter &&
          password[policy.Position2+1] != policy.Letter)         
        {
          correctPasswords++;
        }
        if (password[policy.Position1+1] != policy.Letter &&
          password[policy.Position2+1] == policy.Letter)
        {
          correctPasswords++;
        }
      }
      return correctPasswords;
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
