using Junior.one.HtmlStringManipulation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tests.HtmlStringManipulation
{
    [TestFixture]
    public class TestHtmlToNestedList
    {
        [Test]
        public void GiveParentTags_ShouldNotHaveChildren()
        {
            var input = "<div></div>";
            var expected = new Token()
            {
                Name = "div",
            };

            // Act
            var sut = new PopulateTokenWithHtml();
            var actual = sut.AddHtmToTokenList(input);

            AssertSerializedObject(actual, expected);
        }

        [Test]
        public void GivenOneChild_ShouldReturnOneParentAndOneChild()
        {
            var input = 
                "<div>" +
                    "<div>" +
                        "child 1" +
                    "</div>" +
                "</div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>()
                {
                    new Token() {Name = "div"}
                }
            };

            // Act
            var sut = new PopulateTokenWithHtml();
            var actual = sut.AddHtmToTokenList(input);

            AssertSerializedObject(actual, expected);
        }
        [Test]
        public void GivenTwoOneChildren_ShouldReturnOneParentAndTwoChild()
        {
            var input =
                "<div>" +
                    "<div>" +
                        "child 1" +
                    "</div>" +
                     "<div>" +
                        "child 2" +
                    "</div>" +
                "</div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>()
                {
                    new Token() {Name = "div"},
                    new Token() {Name = "div"}
                }
            };

            // Act
            var sut = new PopulateTokenWithHtml();
            var actual = sut.AddHtmToTokenList(input);

            AssertSerializedObject(actual, expected);
        }

        private void AssertSerializedObject(object object1,object object2)
        {
            Assert.AreEqual(JsonSerializer.Serialize(object1), JsonSerializer.Serialize(object2));
        }
        
        [Test]
        public void GivenTwoAndCloseTag_ShouldWriteOpenTwoOnly()
        {
            var input = "<div><span></span></div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>() { new Token() { Name = "span" } }
            };

            var sut = new PopulateTokenWithHtml();

            var actaul = sut.AddHtmToTokenList(input);

            AssertSerializedObject(expected, actaul);
        }
    }
}
