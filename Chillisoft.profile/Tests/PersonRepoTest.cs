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

            [Test]
            public void GetData_ReturnsListOfStudents()
            {
                // Arrange
                var staffMock = Substitute.For<IGenenricRepository<Student>>();
                var repository = new StudentRepository(staffMock);

                var student1 = new Student { Id = Guid.NewGuid(), FullName = "Alice Smith", Course = "Math", StudentNumber = "12345" };
                var student2 = new Student { Id = Guid.NewGuid(), FullName = "Bob Johnson", Course = "Science", StudentNumber = "67890" };

                // Configure staffMock to return a list of students
                staffMock.GetData().Returns(new List<Student> { student1, student2 });

                // Act
                var students = repository.GetData();

                // Assert
                staffMock.Received(1).GetData();
                CollectionAssert.Contains(students, student1);
                CollectionAssert.Contains(students, student2);
                Assert.AreEqual(2, students.Count);
            }
            public static Student ExpectedStudent(Student staff)
            {
                return Arg.Is<Student>(
                    p => p == staff);
            }
        }
    }
    
}
