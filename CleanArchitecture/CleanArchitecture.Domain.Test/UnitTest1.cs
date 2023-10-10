using CleanArchitechure.InMemoryDB;
using NSubstitute;
using System.Runtime.InteropServices;
using AutoFixture;
using NSubstitute.ReceivedExtensions;

namespace CleanArchitecture.Domain.Test
{
    public class Tests
    {
       

        [TestFixture]
        public class UserInputTests
        {
            private readonly Fixture _fixture;
            
            public UserInputTests()
            {
                _fixture = new Fixture();
            }


            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void Given_EmptyUserFields_ShouldThrowException()
            {
                // Arrange 
                var user = new UserBuilder()
                    .withName("")
                    .withSurname("")
                    .withEmail("")
                    .Build(); ;
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
                var user = new UserBuilder()
                    .withName("Thunyiwe")
                    .withSurname("Mkhize")
                    .withEmail("thunyiwe")
                        .Build();
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
                var user =
                    new UserBuilder()
                        .withName("Thunyiwe")
                        .withSurname("Mkhize")
                        .withEmail("thunyiwe@gmail.com")
                        .Build(); 

                var sut = Substitute.For<InMemoryUserGateway>(); 
                sut.AddUser(user);

                sut.Received(1).AddUser(user);

            }

            [Test]
            public void GivenCorrectObjectType_ShouldBeCalled()
            {
                var user = new UserBuilder()
                    .withName("Thunyiwe")
                    .withSurname("Mkhize")
                    .withEmail("thunyiwe@gmail.com")
                    .Build();

                var sut = MakeMemoryUserGateway();
               

                sut.Received(1).AddUser(user);

            }

            [Test]
            public void Get_User_returnUsers()
            {
                var user = new UserBuilder()
                    .withName("Thunyiwe")
                    .withSurname("Mkhize")
                    .withEmail("thunyiwe@gmail.com")
                    .Build();

                var sut = MakeMemoryUserGateway();
                sut.AddUser(user);

                var users = sut.FindAllUsers();
                Assert.That(users.Count(),Is.GreaterThan(0));
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