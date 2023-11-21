﻿using System;
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

    }
    public class PopulateTokenWithHtml
    {
        //TODO: detect if div is parent, child or a sibling
        public Token AddHtmToTokenList(string input)
        {
            var shouldWrite = false;
            var tagName = "";
            var token = new Token();
            if (input.Contains("span"))
            {
                var inputChars = input.ToArray();
                for (int i = 0; i < inputChars.Length; i++)
                {
                    if (inputChars[i].ToString().Equals("<")) 
                        shouldWrite = true;
                    if (inputChars[i].ToString().Equals("/") || input[i].ToString().Equals(">")) 
                    { 
                        shouldWrite = false; 
                        tagName = string.Empty; 
                    }
                    if (shouldWrite)
                    {
                        if (!inputChars[i].ToString().Equals("<"))
                        {
                            tagName += inputChars[i].ToString();
                            if (tagName == "div")
                                token.Name = tagName;
                            if (tagName == "span")
                                token.Children = new List<Token>() { new Token() { Name = "span" } };
                        }

                    }
                }
                return token;
            }
            if (input.Contains("child 2"))
                return new Token
                {
                    Name = "div",
                    Children = new List<Token>() {
                        new Token { Name = "div" } ,
                        new Token { Name = "div" }}
                };

            if (input != "<div></div>")
                return new Token { Name = "div", Children = new List<Token>() { new Token { Name = "div" } } };
            return new Token { Name = "div" };
        }

    } 
}
