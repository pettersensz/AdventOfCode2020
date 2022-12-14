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
  
    public int RunInstructions(out bool completeProgram)
    {
      completeProgram = false;
      var acc = 0;
      var i = 0;
      var moveNext = true;
      try
      {
        while (moveNext)
        {
          var currentInstruction = _instructions[i];
          if (currentInstruction.Visited)
          {
            moveNext = false;
            continue;
          }
          if (currentInstruction.Operation == Operation.NoOp)
          {
            i++;
          }
          if (currentInstruction.Operation == Operation.Accumulate)
          {
            acc += currentInstruction.Argument;
            i++;
          }
          if (currentInstruction.Operation == Operation.Jump)
          {
            i += currentInstruction.Argument;
          }
          currentInstruction.Visited = true;
        }
      }
      catch (IndexOutOfRangeException)
      {
        completeProgram = true;
      }

      ResetInstructions();
      
      return acc;
    }

    private void ResetInstructions()
    {
      foreach(var instruction in _instructions)
      {
        instruction.Visited = false;
      }
    }

    public int FixProgram()
    {
      for (var i = 0; i < _instructions.Length; i++)
      {
        var instructions = GetFreshInstructions();
        var instruction = instructions[i];
        instruction.Print();
        if(instruction.Operation == Operation.NoOp)
        {
          instruction.Operation = Operation.Jump;
          var result = RunInstructions(out var completeProgram);
          if (completeProgram) return result;
          instruction.Operation = Operation.NoOp;
        }
        else if(instruction.Operation == Operation.Jump)
        {
          instruction.Operation = Operation.NoOp;
          var result = RunInstructions(out var completeProgram);
          if(completeProgram) return result;
          instruction.Operation = Operation.Jump;
        }
      }

      return 0;
    }

    public Instruction[] GetFreshInstructions()
    {
      return (Instruction[])_instructions.Clone();
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
