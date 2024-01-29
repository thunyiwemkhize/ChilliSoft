using System.Text.RegularExpressions;

namespace Junior.One.Token
{
    public class Token
    {
        private string _sourceInput;

        /// <summary>
        /// The position of the first character of the token
        /// </summary>
        public int FirstCharacter { get; set; }
        /// <summary>
        /// The text from htmlInput that occurs between FirstCharacter and LastCharacter (inclusive)
        /// </summary>
        //public string Content { get { return FirstCharacter - LastCharacter > 0 ? _sourceInput.Substring(FirstCharacter, LastCharacter - FirstCharacter) : ""; } }
        public string Content { get; set; }

        /// <summary>
        /// The position of the last character of the token
        /// </summary>
        public int LastCharacter { get; set; }
        /// <summary>
        /// The previous whitespace token
        /// </summary>
        public Token PreviousWhitespace { get; set; }
        /// <summary>
        /// The previous token
        /// </summary>
        public Token Previous { get; set; }
        /// <summary>
        /// The next token
        /// </summary>
        public Token Next { get; set; }
        /// <summary>
        /// The next whitespace token
        /// </summary>
        public Token NextWhitespace { get; set; }
        /// <summary>
        /// The type of the token
        /// </summary>
        public TokenType Type { get; set; }

        public Token(string sourceInput, TokenType type)
        {
            //Type = type;
            _sourceInput = sourceInput;
        }

    }

    public enum TokenType
    {
        DocumentStart,
        DocumentEnd,
        Whitespace,
        Newline,
        StartOpenTag,
        StartCloseTag,
        EndTag,
        Text,
    }
    public class MakeToken
    {
        public string HtmlInput()
        {
            return
                @"<div>
              <bob>
                  <image>
                  </image>
              </bob>
          </div>";
            // DocumentStart,StartOpenTag,Text,EndTag,Newline,
            // Whitespace,StartOpenTag,Text,EndTag,NewLine,
            // Whitespace,StartOpenTag,Text,EndTag,NewLine,
            // Whitespace,StartCloseTag,Text,EndTag,DocumentEnd

        }
        static string ReplaceConsecutiveSpaces(string input)
        {
            // Use regular expression to replace consecutive white spaces with a single space
            return Regex.Replace(input, @"\s+", " ");
        }
        public List<Token> makeToken()
        {
            var tagContent = string.Empty;
            var input = ReplaceConsecutiveSpaces(HtmlInput());
            List<Token> tokens = new List<Token>
            {
                new Token("", TokenType.Text) { Content = "", }
            };
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\n') { AddToken(input, tokens, i, TokenType.Newline); }
                else if (input[i] == ' ') { AddToken(input, tokens, i, TokenType.Whitespace); }
                else if (input[i] == '<')
                {
                    if (input[i + 1] == '/')
                    {
                        AddToken(input, tokens, i, TokenType.StartCloseTag);
                           int endIndex = input.IndexOf('>', i);
                        tagContent = input.Substring(i + 2, endIndex - i - 2);
                        tokens.Add(new Token(input, TokenType.Text)
                        {
                            Content = tagContent,
                            Type = TokenType.Text
                        });
                        i = endIndex;
                    }
                    else
                    {
                        AddToken(input, tokens, i, TokenType.StartOpenTag);

                        int endIndex = input.IndexOf('>', i);
                        tagContent = input.Substring(i + 1, endIndex - i - 1);
                        tokens.Add(new Token(input, TokenType.Text)
                        {
                            Content = tagContent,
                            Type = TokenType.Text
                        });
                        i = endIndex;
                    }
                }
                else if (input[i] == '>') { 
                    AddToken(input, tokens, i, TokenType.EndTag);
                }
                else { AddToken(input, tokens, i, TokenType.Text); }

               
            }
            tokens.Add(new Token("", TokenType.EndTag)
            {
                Content = "",
            });
            return tokens;
        }

        private static void AddToken(string input, List<Token> tokens, int i, TokenType tokenType)
        {
            tokens.Add(new Token(input, TokenType.Text)
            {
                Content = input[i].ToString(),
                Type = tokenType
            });
        }
    }
}
