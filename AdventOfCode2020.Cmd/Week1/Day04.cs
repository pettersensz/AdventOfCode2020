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
          if (split[0] == "pid") PassportIdString = split[1];
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
      if (!IsValidBirthYear(strict)) return false;
      if (!IsValidIssueYear(strict)) return false;
      if (!IsValidExpiryYear(strict)) return false;
      if (!IsValidPassportId(strict)) return false;
      if (!IsValidHeight(strict)) return false;
      if (!IsValidEyeColor(strict)) return false;
      if (!IsValidHairColor(strict)) return false;
      return true;
    }

    public bool IsValidHairColor(bool strict)
    {
      if (HairColor.Length < 1) return false;
      if (!strict) return true;
      //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
      if (HairColor.Length != 7) return false;
      if (HairColor[0] != '#') return false;
      // Possibly check for special characters?
      return true;
    }

    public bool IsValidEyeColor(bool strict)
    {
      if(EyeColor.Length < 1) return false;
      if (!strict) return true;
      // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
      if (EyeColor.Length != 3) return false;
      if (EyeColor == "amb") return true;
      if (EyeColor == "blu") return true;
      if (EyeColor == "brn") return true;
      if (EyeColor == "gry") return true;
      if (EyeColor == "grn") return true;
      if (EyeColor == "hzl") return true;
      if (EyeColor == "oth") return true;
      return false;
    }

    public bool IsValidHeight(bool strict)
    {
      //hgt(Height) - a number followed by either cm or in:
      //If cm, the number must be at least 150 and at most 193.
      //If in, the number must be at least 59 and at most 76.
      if (Height.Length < 1) return false;
      if(!strict) return true;
      if (Height.Contains("cm"))
      {
        if (Height.Length != 5) return false;
        var ok = int.TryParse(Height.Substring(0, 3), out var heightNumber);
        if (!ok) return false;
        if (heightNumber < 150) return false;
        if (heightNumber > 193) return false;
        return true;
      }
      if (Height.Contains("in"))
      {
        if (Height.Length != 4) return false;
        var ok = int.TryParse(Height.Substring(0, 2), out var heightNumber);
        if (!ok) return false;
        if (heightNumber < 59) return false;
        if (heightNumber > 76) return false;
        return true;
      }
      return false;
    }

    public bool IsValidPassportId(bool strict)
    {
      if (PassportIdString.Length < 1) return false;
      if (!strict) return true;
      if (PassportIdString.Length != 9) return false;
      return int.TryParse(PassportIdString, out _);
    }

    public bool IsValidExpiryYear(bool strict)
    {
      if (ExpiryYear == 0) return false;
      if (!strict) return true;
      if (ExpiryYear < 2020) return false;
      if (ExpiryYear > 2030) return false;
      return true;
    }

    public bool IsValidIssueYear(bool strict)
    {
      if (IssueYear == 0) return false;
      if(!strict) return true;
      if (IssueYear < 2010) return false;
      if (IssueYear > 2020) return false;
      return true;
    }

    public bool IsValidBirthYear(bool strict)
    {
      if (BirthYear == 0) return false;
      if (!strict) return true;
      if (BirthYear < 1920) return false;
      if (BirthYear > 2002) return false;
      return true;
    }
  }
}
