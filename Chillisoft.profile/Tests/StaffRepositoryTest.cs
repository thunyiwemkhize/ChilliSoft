using Junior.one.Inharitance.Repository;
using Junior.one.Inharitance.Repository.StaffRepo;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public partial class StaffRepositoryTest
    {
        [Test]
        public void GivenStaff_ShouldCreateStaff()
        {
            // Arrange
            var personRepository = Substitute.For<IGenenricRepository<Staff>>();
            var employee = new StaffBuilder().WithValidStudent().Build();

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
            Staff? nullStaff = null;

            var emptyName = new StaffBuilder().WithInvalidStaffFullName().Build();
            var emptyPosition = new StaffBuilder().WithInvalidStaffPosition().Build();
            var emptyStaffNumber = new StaffBuilder().WithInvalidStaffPosition().Build();


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
