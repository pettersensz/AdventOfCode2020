using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Cmd.Week2
{
  public class Day08
  {
    private string[] _fileData;
    private Instruction[] _instructions;
    public Day08(string filename)
    {
      _fileData = Utils.FileReader.ReadLinesInTextFile(filename);
      _instructions = new Instruction[_fileData.Length];
      for(var i = 0; i < _fileData.Length; i++)
      {
        _instructions[i] = new Instruction(_fileData[i]);
      }
    }
  
    public int RunInstructions()
    {
      var acc = 0;
      var i = 0;
      var moveNext = true;
      while (moveNext)
      {
        var currentInstruction = _instructions[i];
        if (currentInstruction.Visited)
        {
          moveNext = false;
          continue;
        }
        if(currentInstruction.Operation == Operation.NoOp)
        {
          i++;
        }
        if(currentInstruction.Operation == Operation.Accumulate)
        {
          acc += currentInstruction.Argument;
          i++;
        }
        if(currentInstruction.Operation == Operation.Jump)
        {
          i += currentInstruction.Argument;
        }
        currentInstruction.Visited = true;
      }
      return acc;
    }
  
  }



  public class Instruction
  {
    public Operation Operation { get; set; }
    public int Argument { get; set; }
    public bool Visited { get; set; }

    public Instruction(string input)
    {
      var parts = input.Split(' ', StringSplitOptions.TrimEntries);
      if (parts[0] == "nop") Operation = Operation.NoOp;
      else if (parts[0] == "acc") Operation = Operation.Accumulate;
      else if (parts[0] == "jmp") Operation = Operation.Jump;
      Argument = int.Parse(parts[1]);
      Visited = false;
    }

    public void Print()
    {
      Console.WriteLine($"{Operation}, {Argument}, Visited: {Visited}");
    }
  }

  public enum Operation
  {
    NoOp,
    Jump,
    Accumulate
  }
}
