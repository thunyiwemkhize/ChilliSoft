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
                var staffMock = Substitute.For<IGenericRepository<Staff>>();
                var repository = new StaffRepository(staffMock);

                var employee = new StaffBuilder()
                    .WithFullName("Thunyiwe")
                    .WithStaffNumber("853798375")
                    .WithPosition("HOD")
                    .WithId()
                    .Build();

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
                var staffMock = Substitute.For<IGenericRepository<Staff>>();
                var repository = new StaffRepository(staffMock);
                Staff? nullStaff = null;

                var employee = new StaffBuilder()
                    .WithInvalidFullName()
                    .WithStaffNumber("")
                    .WithPosition("")
                    .WithId()
                    .Build();

                // Act/Assert
                Assert.Throws<ArgumentNullException>(() => repository.Create(nullStaff!));
                Assert.Throws<ArgumentNullException>(() => repository.Create(employee));
                Assert.Throws<ArgumentNullException>(() => repository.Create(employee));
                Assert.Throws<ArgumentNullException>(() => repository.Create(employee));

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
                var staffMock = Substitute.For<IGenericRepository<Student>>();
                var repository = new StudentRepository(staffMock);

                var employee = new StudentBuilder()
                    .WithId()
                    .WithStudentNumber("78457894")
                    .WithFullName("Nonhlanhla")
                    .WithStudentCourse("ND: IT")
                    .Build();

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
                var staffMock = Substitute.For<IGenericRepository<Student>>();
                var repository = new StudentRepository(staffMock);
                Student student = null!;

                var invalidStudent = new StudentBuilder().
                    WithFullName("")
                    .WithStudentCourse("")
                    .WithStudentNumber("")
                    .Build();




                Assert.Throws<ArgumentNullException>(() => repository.Create(student));
                Assert.Throws<ArgumentNullException>(() => repository.Create(invalidStudent));
                Assert.Throws<ArgumentNullException>(() => repository.Create(invalidStudent));
                Assert.Throws<ArgumentNullException>(() => repository.Create(invalidStudent));

            }
            [Test]
            public void GetData_ReturnsListOfStudents()
            {
                // Arrange
                var staffMock = Substitute.For<IGenericRepository<Student>>();
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
                Assert.AreEqual(2, students.Count());
            }

            [Test]
            [Ignore("")]
            public void GivenEntity_ShouldRemoveEntity()
            {
                // Arrange
                var staffMock = Substitute.For<IGenericRepository<Staff>>();
                var repository = new GenericRepository<Staff>().GetData();

                var employee = new StaffBuilder()
                    .WithFullName("Thunyiwe")
                    .WithStaffNumber("853798375")
                    .WithPosition("HOD")
                    .WithId()
                    .Build();

                // Act
                var repo =new RepositoryBuilder().WithCreateStaff(employee).WithStaffList(employee).WithStaffList(new List<Staff>() { employee}).Build();
                // Assert

                repo.Remove(employee);
                //Assert.That(remainigStaff.Count(), Is.EqualTo(0));
                Assert.That(repo.GetData().Count(), Is.EqualTo(0));
            }

            [Test]
            [Ignore("")]
            public void Given_ValidStaffAndNullStaff_ShouldNotRemove()
            {
                // Arrange
                var staffMock = Substitute.For<IGenericRepository<Staff>>();
                var repository = new StaffRepository(staffMock);

                var employee = new StaffBuilder()
                    .WithFullName("Thunyiwe")
                    .WithStaffNumber("853798375")
                    .WithPosition("HOD")
                    .WithId()
                    .Build();
                Staff? emptyStaff = null;

                // Act
                staffMock.Create(employee);
                staffMock.Create(emptyStaff!);
                repository.Remove(emptyStaff!);
                var remainigStaff = repository.GetData();
                // Assert

                Assert.That(remainigStaff.Count(), Is.EqualTo(1));
            }
            public static Student ExpectedStudent(Student staff)
            {
                return Arg.Is<Student>(
                    p => p == staff);
            }
        }
        public class RepositoryBuilder
        {
            IGenericRepository<Staff> _repository = Substitute.For<IGenericRepository<Staff>>();
            public GenericRepository<Staff> Build()
            {
                return new GenericRepository<Staff>();
            }
            public RepositoryBuilder WithStaffList(Staff staff)
            {
                _repository.Remove(Arg.Is<Staff>(staff));
                return this;
            }
            public RepositoryBuilder WithStaffList(List<Staff> staff)
            {
                _repository.GetData().Returns(staff);
                return this;
            }
            public RepositoryBuilder WithCreateStaff(Staff staff)
            {
                _repository.Create(Arg.Is<Staff>(x=>x.Id == staff.Id && x.StaffNumber == staff.StaffNumber && staff.FullName == staff.StaffNumber));
                return this;
            }
        }
    }
    
}
