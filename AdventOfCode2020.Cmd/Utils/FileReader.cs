using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Utils
{
  public static class FileReader
  {
    public static string[] ReadLinesInTextFile(string filename)
    {
      var directory = Directory.GetCurrentDirectory();
      var path = Path.GetFullPath(Path.Combine(directory, @"..\..\..\..\Input\" + filename));

      var fileData = File.ReadAllLines(path);
      return fileData;
    }
  }
}
