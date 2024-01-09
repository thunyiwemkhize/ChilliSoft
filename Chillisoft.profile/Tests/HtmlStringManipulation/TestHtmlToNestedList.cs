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

        [Test]
        public void GivenTwoChildren_ShouldWriteOneParentAndTwoChildren()
        {
            var input = "<div><span></span><span></span></div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>() { new Token() { Name = "span" }, new Token() { Name = "span"} }
            };

            var sut = new PopulateTokenWithHtml();

            var actaul = sut.AddHtmToTokenList(input);

            AssertSerializedObject(expected, actaul);
        }

        [Test]
        public void GivenOneParentAndManyChildren_ShouldWriteOneParentAndManyChildren()
        {
            var input = "" +
                "<div>" +
                    "<span></span>" +
                    "<span></span>" +
                    "<span></span>" +
                    "<span></span>" +
                    "<span></span>" +
                    "<span></span>" +
                "</div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>() { 
                    new Token() { Name = "span" }, 
                    new Token() { Name = "span" },
                    new Token() { Name = "span" },
                    new Token() { Name = "span" },
                    new Token() { Name = "span" },
                    new Token() { Name = "span" }
                }
            };

            var sut = new PopulateTokenWithHtml();

            var actaul = sut.AddHtmToTokenList(input);

            AssertSerializedObject(expected, actaul);
        }

        [Test]
        public void GivenOneParentTwoDifferentChildren_ShouldWriteOneParentAndTwoDifferentChildren()
        {
            var input = "<div><span></span><icon></icon></div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>() { 
                    new Token() { Name = "span" }, 
                    new Token() { Name = "icon" } 
                }
            };

            var sut = new PopulateTokenWithHtml();

            var actaul = sut.AddHtmToTokenList(input);

            AssertSerializedObject(expected, actaul);
        }
        [Test]
        public void GivenOneParentAndManyDifferentChildren_ShouldWriteOneParentAndManyChildren()
        {
            var input = "<div><span></span><icon></icon><img></img><text></text><input></input><span></span></div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>() {
                    new Token() { Name = "span" },
                    new Token() { Name = "icon" },
                    new Token() { Name = "img" },
                    new Token() { Name = "text" },
                    new Token() { Name = "input" },
                    new Token() { Name = "span" }
                }
            };

            var sut = new PopulateTokenWithHtml();

            var actaul = sut.AddHtmToTokenList(input);

            AssertSerializedObject(expected, actaul);
        }
        [Test]
        public void GivenOneParentOneChildOneGranddChild()
        {
            var input = "<div>" +
                "<parent>" +
                    "<child>" +
                        "<grandchild>" +
                        "</grandchild>" +
                    "</child>" +
                "</parent>" +
                "</div>";
            var expected = new Token()
            {
                Name = "div",
                Children = new List<Token>() {
                    new Token()
                    {
                        Name = "parent",
                        Children = new List<Token>()
                        {
                            new Token()
                            {
                                Name = "child",
                                Children = new List<Token>
                                {
                                    new Token { Name= "grandchild" }
                                },
                            },
                        },
                     }
                }
            };

            var sut = new PopulateTokenWithHtml();

            var actaul = sut.AddHtmToTokenList(input);

            AssertSerializedObject(expected, actaul);
        }

        public class TestParent
        {

        }
    }
}
