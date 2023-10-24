using Junior.one.Inharitance.Repository;
using Junior.one.Inharitance.Repository.StaffRepo;
using Junior.one.Inharitance.Repository.StudentRepo;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PersonRepoTest
    {
        public class StaffRepositoryTest
        {
            [Test]
            public void GivenStaff_ShouldCreateStaff()
            {
                // Arrange
                var staffMock = Substitute.For<IGenenricRepository<Staff>>();
                var repository = new StaffRepository(staffMock);

                var employee = new StaffBuilder().WithValidStaff().Build();

                // Act
                repository.Create(employee);

                // Assert
                staffMock.Received(1).Create(
                    ExpectedStaff(employee)
                );

            }


            [Test]
            public void GivenInvalidStaff_ShouldThrowException()
            {
                // Arrange
                var staffMock = Substitute.For<IGenenricRepository<Staff>>();
                var repository = new StaffRepository(staffMock);
                Staff? nullStaff = null;

                var emptyName = new StaffBuilder().WithInvalidStaffFullName().Build();
                var emptyPosition = new StaffBuilder().WithInvalidStaffPosition().Build();
                var emptyStaffNumber = new StaffBuilder().WithInvalidStaffPosition().Build();


                Assert.Throws<ArgumentNullException>(() => repository.Create(nullStaff));
                Assert.Throws<ArgumentNullException>(() => repository.Create(emptyName));
                Assert.Throws<ArgumentNullException>(() => repository.Create(emptyPosition));
                Assert.Throws<ArgumentNullException>(() => repository.Create(emptyStaffNumber));

            }

            public static Staff ExpectedStaff(Staff staff)
            {
                return Arg.Is<Staff>(
                    p => p == staff);
            }
        }

        public class StudentRepositoryTest
        {
            [Test]
            public void GivenStudent_ShouldCreateStudent()
            {
                // Arrange
                var staffMock = Substitute.For<IGenenricRepository<Student>>();
                var repository = new StudentRepository(staffMock);

                var employee = new StudentBuilder().WithValidStaff().Build();

                // Act
                repository.Create(employee);

                // Assert
                staffMock.Received(1).Create(
                    ExpectedStudent(employee)
                );

            }

            [Test]
            public void GivenInvalidStudent_ShouldThrowException()
            {
                // Arrange
                var staffMock = Substitute.For<IGenenricRepository<Student>>();
                var repository = new StudentRepository(staffMock);
                Student student = null!;

                var emptyName = new StudentBuilder().WithInValidStudentFullName().Build();
                var emptyPosition = new StudentBuilder().WithInValidStudentCourse().Build();
                var emptyStaffNumber = new StudentBuilder().WithInValidStudentNumber().Build();


                Assert.Throws<ArgumentNullException>(() => repository.Create(student));
                Assert.Throws<ArgumentNullException>(() => repository.Create(emptyName));
                Assert.Throws<ArgumentNullException>(() => repository.Create(emptyPosition));
                Assert.Throws<ArgumentNullException>(() => repository.Create(emptyStaffNumber));

            }
            public static Student ExpectedStudent(Student staff)
            {
                return Arg.Is<Student>(
                    p => p == staff);
            }
        }
    }
    
}
