using System;
using System.IO;

namespace SmileyScript
{
    class Program 
    {
        static void Main(String[] args) 
        {
            var tokenizer = new Tokenizer();

            var filePath = args[0];
            if (!File.Exists(filePath) || filePath == null)
            {
                Console.WriteLine("File couldn't be found.");
            }

            var tokens = tokenizer.Tokenize(File.ReadAllText(filePath));

            var turingMachine = new TuringMachine(tokens);
            turingMachine.Run();
        }
    }
}