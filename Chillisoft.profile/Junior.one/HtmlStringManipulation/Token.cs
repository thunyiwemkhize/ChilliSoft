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
        public Token PopulateTokenWithHtmlTags(string htmlInput)
        {
            var tokenStack = new Stack<Token>();

            for (int i = 0; i < htmlInput.Length; i++)
            {
                if (htmlInput[i] == '<')
                {
                    if (htmlInput[i + 1] == '/')
                    {
                        // Closing tag

                        int endIndex = htmlInput.IndexOf('>', i);
                        RemoveTheFirstStackObject(htmlInput, tokenStack, i, endIndex);
                        i = endIndex;
                    }
                    else
                    {
                        // Opening tag

                        int endIndex = htmlInput.IndexOf('>', i);
                        PopulateTokenStack(htmlInput, tokenStack, i, endIndex);
                        i = endIndex;
                    }
                }
            }

            return tokenStack.First();  
        }

        private void PopulateTokenStack(string htmlInput, Stack<Token> tokenStack, int i, int endIndex)
        {
            string currentTagName = MakeTagName(htmlInput, i + 1, endIndex - i - 1);

            var newElement = new Token { Name = currentTagName };

            if (tokenStack.Count > 0)
            {
                tokenStack.Peek().Children?.Add(newElement);
            }

            tokenStack.Push(newElement);
        }

        private void RemoveTheFirstStackObject(string htmlInput, Stack<Token> tokenStack, int i, int endIndex)
        {
            string currentTagName = MakeTagName(htmlInput, i + 2, endIndex - i - 2);
            if (tokenStack.Count > 1 && tokenStack.Peek().Name == currentTagName)
            {
                tokenStack.Pop();
            }
        }

        private string MakeTagName(string htmlInput, int startIndex, int length)
        {
            string tagName = htmlInput.Substring(startIndex, length).Trim();
            return tagName;
        }
    } 

   
}

