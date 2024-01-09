using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.HtmlStringManipulation
{
    public class Token
    {
        public string? Name { get; set; }
        public IList<Token>? Children { get; set; }
        public Token() { 
            Children = new List<Token>();
        }

    }
    public class PopulateTokenWithHtml
    {
        public Token AddHtmToTokenList(string htmlInput)
        {
            var stack = new Stack<Token>();

            for (int i = 0; i < htmlInput.Length; i++)
            {
                if (htmlInput[i] == '<')
                {
                    if (htmlInput[i + 1] == '/')
                    {
                        // Closing tag
                        int endIndex = htmlInput.IndexOf('>', i);
                        string closingTag = htmlInput.Substring(i + 2, endIndex - i - 2).Trim();

                        if (stack.Count > 1 && stack.Peek().Name == closingTag)
                        {
                            stack.Pop();
                        }

                        i = endIndex;
                    }
                    else
                    {

                        // Opening tag
                        int endIndex = htmlInput.IndexOf('>', i);
                        string openingTag = htmlInput.Substring(i + 1, endIndex - i - 1).Trim();

                        var newElement = new Token { Name = openingTag };

                        if (stack.Count > 0)
                        {
                            stack.Peek().Children?.Add(newElement);
                        }

                        stack.Push(newElement);

                        i = endIndex;
                    }
                }
            }

            return stack.First();  
        }

    } 
}

