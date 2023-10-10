using System.Collections;
using Junior.one.Generics;
using NSubstitute;

namespace Junior.one.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestArrayList()
        {
            // arrange 
            var collect = MakePeople(3);
            var mock = Substitute.For<CollectAndDisplayPersonInformation>();

            // sut
            var actual = mock.RequestPersonInformation(collect);

            // assert
            Assert.That(actual.Count, Is.EqualTo(3));
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