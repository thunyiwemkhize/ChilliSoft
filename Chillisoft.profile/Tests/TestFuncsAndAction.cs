using Junior.one.Delegates;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestFuncsAndAction
    {
        [Test]
        public void GivenOneValue_ShouldReeturnGivenValueAsAvarrage()
        {
            // Arrange 
            var numbers = new List<int>()
            {
                1
            };
            var expected = 1;
            //Act

            var actual = FuncsAndActions.CalculateAvarage(numbers);
            //Assert

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenMultipleValues_ShouldReturnAvarageForAllNumbers()
        {
            // Arrange
            var numbers = new List<int>()
            {
                1,2,3,4,5
            };
            var expected = 3;

            //Act

            var actual = FuncsAndActions.CalculateAvarage(numbers);

            // Assert
            Assert.AreEqual(expected,actual);

        }

        public class TestMaximum
        {
            [Test]
            public void GivenOneValue_ShouldReturnValue()
            {
                // Arrange
                var numbers = new List<int>() { 5 };
                var expected = 5;
                // Act

                var actual = FuncsAndActions.CalculateMaximum(numbers);

                // Assert

                Assert.AreEqual(expected,actual);
            }

            [Test]
            public void GivenManyNumbers_ShouldReturnMaxValue()
            {
                // Arrange
                var numbers = new List<int>() { 5, 66, 98,3 ,6, 12 };
                var expected = 98;
                // Act

                var actual = FuncsAndActions.CalculateMaximum(numbers);

                // Assert

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
