using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using JSONSerialization;
using Moq;
using NUnit.Framework;

namespace ClassesTests
{
    [TestFixture]
    public class PhoneBookTests
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

        private PhoneBook book;

        [SetUp]
        public void Init()
        {
            var input = mockHumans[0]; 

            var reader = new Mock<IReader>();
            var saver = new Mock<ISaver>();
            var parser = new HumanParser();

            reader.SetupSequence(r => r.ReadLine())
                                    .Returns(input[0])
                                    .Returns(input[1])
                                    .Returns(input[2])
                                    .Returns(input[3])
                                    .Returns(input[4])
                                    .Returns(input[5]);

            book = new PhoneBook(reader.Object, saver.Object, parser);
            book.Init();
        }

        [TearDown]
        public void Dispose()
        {
             
        }

        [Test]
        [TestCaseSource("mockHumans")]
        public void PhoneBookShouldSaveReadedData(string[] input)
        {
            Assert.AreEqual(book.GetHumanData().Length, input.Length);
        }

        [Test]
        public void PhoneBookFindByName()
        {
            var actual = book.Find("shmatkata");
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
        public void PhoneBookFindByNameAndTown()
        {
            var actual = book.Find("Gancho", "Sofia");
            var expected = new Human[]
            {
                new Human { FirstName = "Bat", MiddleName = "Gancho", Town = "Sofia", Number = "02 946 946 946" },
                new Human { FirstName = "Gancho", MiddleName = "Hubaveca", Town = "Sofia", Number = "++359 34 34 34 34" }
            };

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }

        //[Test]
        //[TestCase("Micky Maus", "Sofia", null)]
        //[TestCase("Micky Maus", "Sofia", "")]
        //[TestCase("Micky Maus", null, "0888 934564")]
        //[TestCase("Micky Maus", "", "0888 934564")]
        //[TestCase(null, "Sofia", "0888 934564")]
        //[TestCase("", "Sofia", "0888 934564")]
        //public void PhoneBookAddWithInvalidDataShouldThrowException(string name, string town, string number)
        //{
        //    Assert.Throws<ArgumentException>(() => book.Add(name, town, number));
        //}

        [Test]
        [TestCase("Micky Maus", "Sofia", "0989 34 34 34")]
        [TestCase("Ani", "Sagora", "02 34 34 34")]
        public void PhoneBookAdd(string name, string town, string number)
        {
            var parser = new HumanParser();
            var human = parser.CreateHuman(new string[] {name, town, number});
            book.Add(human);

            var actual = book.GetHumanData();

            Assert.AreEqual(mockHumans[0].Length + 1, actual.Length);
            Assert.AreEqual(town, actual.Last().Town);
            Assert.AreEqual(number, actual.Last().Number);
        }

        [Test]
        public void PhoneBookJsonSerialize()
        {
            var data = book.Find("Gancho", "Sofia");
            var actual = book.Serialize(data, SerializeType.Json);

            var expectedData = new IHuman[]
            {
                new Human { FirstName = "Bat", MiddleName = "Gancho", Town = "Sofia", Number = "02 946 946 946" },
                new Human { FirstName = "Gancho", MiddleName = "Hubaveca", Town = "Sofia", Number = "++359 34 34 34 34" }
            };

            var expected = new JavaScriptSerializer().Serialize(expectedData);

            Assert.AreEqual(expected, actual);
        }

    }
}
