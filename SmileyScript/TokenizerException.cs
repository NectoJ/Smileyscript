using System;
using System.Collections.Generic;
using System.Text;

namespace SmileyScript
{
    public class TokenizerException : Exception
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public TokenizerException(string message, int line, int column) : base(message)
        {
            Line = line;
            Column = column;
        }
    }
}
