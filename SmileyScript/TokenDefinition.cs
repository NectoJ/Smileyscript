using SmileyScript;
using System.Text.RegularExpressions;

public class TokenDefinition
{
    public Regex regex;
    public TokenType returnsToken;

    public TokenDefinition(TokenType returnsToken, Regex regexPattern)
    {
        this.regex = regexPattern;
        this.returnsToken = returnsToken;
    }

    public TokenDefinition(TokenType returnsToken, string regexPattern)
        : this(new Regex(regexPattern, RegexOptions.Multiline), returnsToken)
    {
    }

    public TokenDefinition(Regex regex, TokenType returnsToken)
    {
        this.regex = regex;
        this.returnsToken = returnsToken;
    }

    public TokenMatch Match(string inputString)
    {
        var match = regex.Match(inputString);
        if (match.Success) 
        {
            string remainingText = string.Empty;
            if (match.Length != inputString.Length)
            {
                remainingText = inputString.Substring(match.Length);
            }

            return new TokenMatch()
            {
                IsMatch = true,
                RemainingText = remainingText,
                TokenType = returnsToken,
                Value = match.Value
            };
        }
        else
        {
            return new TokenMatch()
            {
                IsMatch = false
            };
        }
    }

} 