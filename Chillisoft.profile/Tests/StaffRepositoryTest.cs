using Junior.one.Generics.Repository.Staff;
using Junior.one.Inharitance;
using Junior.one.Inharitance.Repository.Staff;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class StaffRepositoryTest
    {
        [Test]
        public void GivenStaff_ShouldCreateStaff()
        {
            // Arrange
            var personRepository = Substitute.For<IStaffRepository>();
            var employee = new Staff()
            {
                Id = Guid.Parse("6dd40b2f-2631-4ce2-91da-e4c5a5d2b378"),
                FullName = "John Snow",
                Position = "Lecture",
                StaffNumber = "84764756"
            };

            // Act
            personRepository.Create(employee);

            // Assert
            personRepository.Received(1).Create(
                ExpectedPerson(
                Guid.Parse("6dd40b2f-2631-4ce2-91da-e4c5a5d2b378"),
                "John Snow",
                "Lecture",
                "84764756")
            );

        }

        [Test]
        public void GivenInvalidStaff_ShouldThrowException()
        {
            // Arrange
            var repository = new StaffRepository();
            Staff nullStaff = null;

            var emptyName = new Staff()
            {
                Id = Guid.NewGuid(),
                FullName = string.Empty,
                Position = "HOD",
                StaffNumber = "123456787",
            };

            var emptyPosition = new Staff()
            {
                Id = Guid.NewGuid(),
                FullName = "Jessica Nkosi",
                Position = string.Empty,
                StaffNumber = "12345678",
            };

            var emptyStaffNumber = new Staff()
            {
                Id = Guid.NewGuid(),
                FullName = "Thunyiwe Mkhize",
                Position = "Juinor HOD",
                StaffNumber = string.Empty,
            };


            Assert.Throws<ArgumentNullException>(() => repository.Create(nullStaff));
            Assert.Throws<ArgumentNullException>(() => repository.Create(emptyName));
            Assert.Throws<ArgumentNullException>(() => repository.Create(emptyPosition));
            Assert.Throws<ArgumentNullException>(() => repository.Create(emptyStaffNumber));

        }

        public static Staff ExpectedPerson(Guid expectedId, string expectedFullName, string expectedPosition, string expectedStaffNumber)
        {
            return Arg.Is<Staff>(
                p => p.Id == expectedId && 
                     p.FullName.Equals(expectedFullName) && 
                     p.Position.Equals(expectedPosition) && 
                     p.StaffNumber.Equals(expectedStaffNumber)
                );
        }
    }
}
