namespace AdventOfCode2020.Cmd.Week1
{
  public class Day04
  {
    private string[] _input;
    private List<Passport> _passports;

    public Day04(string filename)
    {
      _input = Utils.FileReader.ReadLinesInTextFile(filename); 
      _passports = new List<Passport>();
      var textLines = new List<string>();
      foreach (string line in _input)
      {
        if(line.Length < 1)
        {
          var passport = new Passport(textLines);
          _passports.Add(passport);
          textLines = new List<string>();
        }
        else
        {
          textLines.Add(line);
        }
      }
      // Add last entry
      var lastPassport = new Passport(textLines);
      _passports.Add(lastPassport);
    }

    public int HowManyValidPassports(bool strict)
    {
      var validPassports = 0;
      foreach(var passport in _passports)
      {
        if (passport.IsValid(strict)) validPassports++;
      }
      return validPassports;
    }
  }

  public class Passport
  {
    public int BirthYear;
    public int IssueYear;
    public int ExpiryYear;
    public string Height; //TODO To change to number need unit conversion
    public string EyeColor; //TODO store as color
    public string HairColor;
    public int PassportId;
    public string PassportIdString;
    public int CountryId;

    public Passport(List<string> input)
    {
      var allInputs = new List<string>();
      foreach(var line in input)
      {
        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach(var part in parts)
        {
          allInputs.Add(part);
        }
      }
      EyeColor = "";
      HairColor = "";
      Height = "";
      PassportIdString = "";
      foreach(var entry in allInputs)
      {
        var split = entry.Split(':', StringSplitOptions.RemoveEmptyEntries);
        if(split.Length == 2)
        {
          if (split[0] == "byr") BirthYear = int.Parse(split[1]);
          if (split[0] == "iyr") IssueYear = int.Parse(split[1]);
          if (split[0] == "eyr") ExpiryYear = int.Parse(split[1]);
          if (split[0] == "hgt") Height = split[1];
          if (split[0] == "ecl") EyeColor = split[1];
          if (split[0] == "hcl") HairColor = split[1];
          if (split[0] == "pid")
          {
            int.TryParse(split[1], out PassportId);
            PassportIdString = split[1];
          }
          if (split[0] == "cid") CountryId = int.Parse(split[1]);
        }
        else
        {
          Console.WriteLine("Oh!");
        }
      }
    }

    public bool IsValid(bool strict)
    {
      if(BirthYear == 0 || IssueYear == 0 || ExpiryYear == 0) return false;
      if (strict)
      {
        if (PassportId == 0) return false;
      } else
      {
        if (PassportIdString.Length < 1) return false;
      }

      if (Height.Length < 1 || EyeColor.Length < 1 || HairColor.Length < 1) return false;
      return true;
    }
  }
}
