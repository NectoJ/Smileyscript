
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmileyScript
{

    public class Tokenizer
    {
        private readonly List<TokenDefinition> _tokenDefinitions;

        public Tokenizer()
        {
            // Load token definitions.
            _tokenDefinitions = new List<TokenDefinition>
            {
                new TokenDefinition(TokenType.Increment, @":\)"),
                new TokenDefinition(TokenType.Decrement, @":\("),
                new TokenDefinition(TokenType.PointerLeft, @":\<"),
                new TokenDefinition(TokenType.PointerRight, @":\>"),
                new TokenDefinition(TokenType.StartLoop, @":\["),
                new TokenDefinition(TokenType.EndLoop, @":\]"),
                new TokenDefinition(TokenType.Input, @":I"),
                new TokenDefinition(TokenType.Output, @":O"),
                new TokenDefinition(TokenType.Space, @"\s+?")
            };
        }

        private static int GetLinePosition(string source, string remaining)
        {
            return source.Count(c => c == '\n') - remaining.Count(c => c == '\n') + 1;
        }

        private static int GetColumnPosition(string source, string remaining)
        {
            var processed = source.Substring(0, source.Length - remaining.Length);
            return processed.Length - processed.LastIndexOf('\n');
        }

        public IList<Token> Tokenize(string source)
        {
            var tokens = new List<Token>();
            string remainingText = source;

            while (!string.IsNullOrWhiteSpace(remainingText))
            {
                var matches = false;

                foreach (var tokenDefinition in _tokenDefinitions)
                {
                    var match = tokenDefinition.regex.Match(remainingText);
                    if (match.Success && match.Index == 0)
                    {
                        tokens.Add(new Token(tokenDefinition.returnsToken, match.Value,
                            GetColumnPosition(source, remainingText), GetLinePosition(source, remainingText)));

                        remainingText = tokenDefinition.regex.Replace(remainingText, string.Empty, 1);
                        matches = true;
                        break;
                    }
                }

                if (!matches)
                {
                    var line = GetLinePosition(source, remainingText);
                    var column = GetColumnPosition(source, remainingText);
                    var character = remainingText.First();
                    throw new TokenizerException($"Unexpected error '{character}' occured at line {line} column {column}.", 
                        line, column);
                }

            }
            return tokens;

        }


    }

}