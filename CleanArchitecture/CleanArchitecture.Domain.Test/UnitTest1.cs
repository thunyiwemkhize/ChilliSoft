using CleanArchitechure.InMemoryDB;
using NSubstitute;
using System.Runtime.InteropServices;
using NSubstitute.ReceivedExtensions;

namespace CleanArchitecture.Domain.Test
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class UserInputTests
        {
            [Test]
            public void Given_EmptyUserFields_ShouldThrowException()
            {
                // Arrange 
                var user = MakeUser();
                var sut = MakeMemoryUserGateway();

                //Act
                //Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut.AddUser(user);
                });

            }

            [Test]
            public void Given_InvalidEmailAddress_ShouldThrowException()
            {
                // Arrange
                var user = new User()
                {
                    Name = "Thunyiwe",
                    Surname = "Mkhize",
                    Email = "thunyiwe"
                };

                var sut = MakeMemoryUserGateway();

                //Act
                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    sut.AddUser(user);
                });
            }

            [Test]
            public void Given_ValidValues_ShouldBeCalled()
            {
                var user = new User()
                {
                    Name = "Thunyiwe",
                    Surname = "Mkhize",
                    Email = "thunyiwe@gmail.com"
                };

                var sut = Substitute.For<InMemoryUserGateway>(); 
                sut.AddUser(user);

                sut.Received(1).AddUser(user);

            
            }
            
            InMemoryUserGateway MakeMemoryUserGateway()
            {
                return Substitute.For<InMemoryUserGateway>();
            }

            User MakeUser()
            {
                return new();
            }
        }

        

    }
}