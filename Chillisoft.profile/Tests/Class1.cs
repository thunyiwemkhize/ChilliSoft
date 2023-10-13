using Junior.one.Generics;
using NSubstitute;
using NUnit.Framework;
using System.Collections;
using Moq;

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
                Age = 567
            };
         

            var list = new Mock<ICollectAndDisplayPersonInformation>();
            list.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(employee);

            var implentation = new Implementation(list.Object);

            var res = implentation.getById(567);
            Assert.IsNotNull(res);
            Assert.That(employee, Is.EqualTo(res));

        }
        [Test]
        public void TestArrayList()
        {
            // arrange 
            
           // var collect = MakePeople(3);
           // var mock = new Mock<ICollectAndDisplayPersonInformation>();
           
           // var implentation = new Implementation(mock.Object);

           // // sut
           // //var actual = mock.Setup(m => m.RequestPersonInformation(collect)).Returns(collect);

           // // assert
           //Assert.That(collect.Count, Is.);
        }

        private ArrayList MakePeople(int totalCount)
        {
            var arrayList = new ArrayList();
            for (int i = 0; i < totalCount; i++)
            {
                arrayList.Add(new Person
                {
                    Name = "Juan",
                    Age = 26
                });
                arrayList.Add(new Person
                {
                    Name = "Sara",
                    Age = 31
                });
                arrayList.Add(new Person
                {
                    Name = "Carlos",
                    Age = 23
                });
            }

            return arrayList;
        }
    }
}