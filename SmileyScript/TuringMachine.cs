using System;
using System.Collections.Generic;
using System.Text;

namespace SmileyScript
{
    class TuringMachine
    {
        private IList<Token> program;
        private int length;
        private int pointer;
        private byte[] memory;
        private int memoryPointer;

        public TuringMachine(IList<Token> program)
        {
            this.program = program;
            length = this.program.Count;

            memory = new byte[32768];
            memoryPointer = 0;
        }

        private void Jump(bool forward, Dictionary<TokenType, int> tokens)
        {
            int jumps = 1;
            while (jumps > 0)
            {
                pointer += forward ? 1 : -1;
                if (tokens.ContainsKey(program[pointer].TokenType))
                {
                    jumps += tokens[program[pointer].TokenType];
                }
            }
        }

        public void Run()
        {
            while (pointer < length)
            {
                switch (program[pointer].TokenType)
                {
                    // Increment current cell value.
                    case TokenType.Increment:
                        memory[memoryPointer]++;
                        break;
                    // Decrement current cell value.
                    case TokenType.Decrement:
                        memory[memoryPointer]--;
                        break;
                    // Move pointer one cell to the left.
                    case TokenType.PointerLeft:
                        memoryPointer--;
                        break;
                    // Move pointer one cell to the right.
                    case TokenType.PointerRight:
                        memoryPointer++;
                        break;
                    // Begin the loop sequence. If the current cell is 0, then loop from the beginning.
                    case TokenType.StartLoop:
                        Dictionary<TokenType, int> startJumpValues = new Dictionary<TokenType, int>
                        {
                            { TokenType.StartLoop, 1 },
                            { TokenType.EndLoop, -1 }
                        };

                        if (memory[memoryPointer] == 0)
                        {
                            Jump(true, startJumpValues);
                        }
                        break;
                    // End the loop sequence. If the current cell is not 0, then loop from the beginning.
                    case TokenType.EndLoop:
                        Dictionary<TokenType, int> endJumpValues = new Dictionary<TokenType, int>
                        {
                            { TokenType.StartLoop, -1 },
                            { TokenType.EndLoop, 1 }
                        };

                        if (memory[memoryPointer] != 0)
                        {
                            Jump(false, endJumpValues);
                        }
                        break;
                    // Takes a single input.
                    case TokenType.Input:
                        memory[memoryPointer] = (byte)Console.Read();
                        break;
                    // Returns a single output.
                    case TokenType.Output:
                        Console.Write(Encoding.ASCII.GetChars(new byte[] { memory[memoryPointer] }));
                        break;
                    // Just a space ignore it lol
                    case TokenType.Space:
                        break;
                    default:
                        break;
                }
                pointer++;
            }
        }

    }
}
