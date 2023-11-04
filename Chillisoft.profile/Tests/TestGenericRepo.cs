using Junior.one.Inharitance.Repository;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class TestGenericRepo
    {
        [Test]
        public void GivenEmptyEntity_ShouldThrowError()
        {
            //Arrange 
            var staff = new StaffBuilder().WithEmptyStaff().Build();
            var repo = new GenericStaffRrepositoryBuilder().WithStaffRepo().build();

            //Act

            Assert.Throws<ArgumentNullException>(() => repo.Create(null!));

        }

        internal class GenericStaffRrepositoryBuilder
        {
            private readonly IGenericRepository<Staff> repository = new GenericRepository<Staff>();

            public GenericStaffRrepositoryBuilder WithStaffRepo()
            {
                var repo = Substitute.For<IGenericRepository<Staff>>();
                repo.Create(Arg.Any<Staff>());
                return this;
            }

            public IGenericRepository<Staff> build() { return repository; }
        }
    }
}
