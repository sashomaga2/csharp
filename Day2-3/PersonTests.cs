using System;
using ClassesLesson;
using NUnit.Framework;

namespace ClassesTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase("Sasho", 20)]
        [TestCase("Pesho", 44)]
        [TestCase("Goro", 34)]
        public void ConstructorOverloadsMacthToString(string name, int age)
        {
            // no param constructor
            var sut = new Person();
            Assert.AreEqual($"{Person.DefaultName} {Person.DefaultAge}", sut.ToString());
            // constructor with name
            sut = new Person(name);
            Assert.AreEqual($"{name} {Person.DefaultAge}", sut.ToString());
            // constructor with name and age
            sut = new Person(name, age);
            Assert.AreEqual($"{name} {age}", sut.ToString());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void EmptyOrNullNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Person(name));

            Assert.Throws<ArgumentException>(() => new Person(name));

        }

        [Test]
        [TestCase("Sasho", -1)]
        public void NegativeAgeShouldThrowException(string name, int age)
        {
            Assert.Throws<ArgumentException>(() => new Person(name, age));
        }
    }
}
