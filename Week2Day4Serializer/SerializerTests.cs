using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONSerialization;
using Moq;
using NUnit.Framework;

namespace ClassesTests
{
    [TestFixture]
    public class SerializerTests
    {
        private static string[][] mockHumans = new string[1][]
        {
            new[]
            {
                "Mimi shmatkata | Plovdiv | 0888 9876545",
                "Kireto			| Varna | 052 2945 67",
                "Daniela Ivanova Petrova | Karnobat | 0897 34 34 34",
                "Bat Gancho | Sofia | 02 946 946 946",
                "Bobi shmatkata | Sofia | 02 946 946 946",
                "Gancho Hubaveca | Sofia | ++359 34 34 34 34"
            }
        };

        private Api api;

        [SetUp]
        public void Init()
        {
            var input = mockHumans[0]; 

            var reader = new Mock<IReader>();

            reader.SetupSequence(r => r.ReadLine())
                                    .Returns(input[0])
                                    .Returns(input[1])
                                    .Returns(input[2])
                                    .Returns(input[3])
                                    .Returns(input[4])
                                    .Returns(input[5]);

            api = new Api(reader.Object);
            api.Init();
        }

        [TearDown]
        public void Dispose()
        {
             
        }

        [Test]
        [TestCaseSource("mockHumans")]
        public void ApiShouldSaveReadedData(string[] input)
        {
            Assert.AreEqual(api.GetHumanData().Length, input.Length);
        }

        [Test]
        public void ApiFindByName()
        {
            var actual = api.Find("shmatkata");
            var expected = new Human[]
            {
                new Human { FirstName = "Mimi", MiddleName = "shmatkata", Town = "Plovdiv", Number = "0888 9876545" },
                new Human { FirstName = "Bobi", MiddleName = "shmatkata", Town = "Sofia", Number = "02 946 946 946" }
            };

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }

        [Test]
        public void ApiFindByNameAndTown()
        {
            var actual = api.Find("Gancho", "Sofia");
            var expected = new Human[]
            {
                new Human { FirstName = "Bat", MiddleName = "Gancho", Town = "Sofia", Number = "02 946 946 946" },
                new Human { FirstName = "Gancho", MiddleName = "Hubaveca", Town = "Sofia", Number = "++359 34 34 34 34" }
            };

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }

        [Test]
        public void AddWithInvalidDataShouldThrowException()
        {
            
        }

        [Test]
        public void ApiAdd()
        {

        }

    }
}
