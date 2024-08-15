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
            Type = type;
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
                @"<div><bob><image></image></bob></div>";
          //  return
          //      @"<div>
          //    <bob>
          //        <image>
          //        </image>
          //    </bob>
          //</div1>";
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
            var input = ReplaceConsecutiveSpaces(HtmlInput());
            List<Token> tokens = new List<Token>
            {
                new Token("", TokenType.DocumentStart) { Content = "", }
            };
            int endIndexToRemember = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\n') { AddToken(input, tokens, i, TokenType.Newline); }
                else if (input[i] == ' ') { AddToken(input, tokens, i, TokenType.Whitespace); }
                else if (input[i] == '<')
                {
                    string? tagContent;
                    if (input[i + 1] == '/')
                    {
                        
                        int endIndex = input.IndexOf('>', i);
                        tagContent = input.Substring(i + 2, endIndex - i - 2);
                        tokens.Add(new Token(input, TokenType.Text)
                        {
                            Content = tagContent,
                            FirstCharacter = i,
                            LastCharacter = endIndex
                        });
                        i = endIndex;
                    }
                    else
                    {

                        int endIndex = input.IndexOf('>', i);
                        
                        tagContent = input.Substring(i + 1, endIndex - i - 1);
                        tokens.Add(new Token(input, TokenType.Text)
                        { 
                            Content = tagContent,
                            FirstCharacter = i,
                            LastCharacter = endIndex 
                        });
                        i = endIndex;
                        var endToken = MakeEndToken(input, input.Length - endIndex);
                    }
                }
            }
            tokens.Add(new Token("", TokenType.DocumentEnd)
            { 
                Content = "",
            });
            return tokens;
        }

        public List<string> MakeListEndTags(string input,
            int endIndex)
        {
            var token = new List<string>();
            for (int i = input.Length; i-- > 0;)
            {
                if (input[i] == '<')
                {
                    if (input[i + 1] == '/')
                    {
                        string? tagContent;
                        endIndex = input.IndexOf('>', i);
                        tagContent = input.Substring(i + 2, endIndex - i - 2);
                        token.Add(tagContent);
                        i = endIndex;
                    }
                }
            }
            return token;
        }
        public Token MakeEndToken(string input,int indexToRemember)
        {
            var token = new Token(input, TokenType.EndTag);
            for (indexToRemember = input.Length; indexToRemember-- > 0;)
            {
                if (input[indexToRemember] == '<')
                {
                    if (input[indexToRemember + 1] == '/')
                    {
                        string? tagContent;
                        int endIndex = input.IndexOf('>', indexToRemember);
                        tagContent = input.Substring(indexToRemember + 2, endIndex - indexToRemember - 2);
                        token.Content = tagContent;
                        break;
                    }
                }
            }
            return token;
        }
        public Token MakeEndToken(string input)
        {
            var token = new Token(input, TokenType.EndTag);
            for (int i = input.Length; i-- > 0;) 
            {
                if (input[i] == '<')
                {
                    if (input[i + 1] == '/')
                    {
                        string? tagContent;
                        int endIndex = input.IndexOf('>', i);
                        tagContent = input.Substring(i + 2, endIndex - i - 2);
                        token.Content = tagContent;
                        break;
                    }
                }
            }
            return token;
        }

        private void AddToken(string input, List<Token> tokens, int i, TokenType tokenType)
        {
            tokens.Add(new Token(input, TokenType.Text)
            {
                Content = input[i].ToString(),
                Type = tokenType
            });
        }
    }
}
