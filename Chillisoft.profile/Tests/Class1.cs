﻿using Junior.one.Generics;
using NUnit.Framework;
using Moq;
using NSubstitute;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            var employee = new Person
            {
                Name = "Juan",
                Age = 26
            };
         

            var list = Substitute.For<ICollectAndDisplayPersonInformation>();
            list.GetPerson(It.IsAny<int>()).Returns(employee);

            var implentation = new Implementation(list);

            implentation.getById(4);

        }
        [Test]
        public void TestWithNSubstitute()
        {
            var employee = new Person
            {
                Name = "Juan",
                Age = 567
            };


            var list = new Mock<ICollectAndDisplayPersonInformation>();
            list.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(employee);

            var implentation = new Implementation(list.Object);

            var res = implentation.getById(567);
            Assert.IsNotNull(res);
            Assert.That(employee, Is.EqualTo(res));

        }

        //private List<Person> MakePeople(int totalCount)
        //{
        //    var arrayList = new ArrayList();
        //    for (int i = 0; i < totalCount; i++)
        //    {
        //        arrayList.Add(new Person
        //        {
        //            Name = "Juan",
        //            Age = 26
        //        });
        //        arrayList.Add(new Person
        //        {
        //            Name = "Sara",
        //            Age = 31
        //        });
        //        arrayList.Add(new Person
        //        {
        //            Name = "Carlos",
        //            Age = 23
        //        });
        //    }

        //    return arrayList;
        //}
    }
}