using System;
using System.Collections.Generic;
using System.Text;

namespace SmileyScript
{
    public class Token
    {

        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public int Column { get; }
        public int Line { get; }

        public Token(TokenType tokenType, string value, int column, int line)
        {
            TokenType = tokenType;
            Value = value;
            Column = column - 1;
            Line = line - 1;
        }
    }
}
