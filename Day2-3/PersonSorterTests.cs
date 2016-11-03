using System;
using System.Runtime.CompilerServices;
using ClassesLesson;
using Moq;
using NUnit.Framework;

namespace ClassesTests
{
    [TestFixture]
    public class PersonSorterTests
    {
        [Test]
        [TestCase("Sasho//34", "Pesho//10", "Ivan//55", "quit", "Misho//11")]
        public void ReadShouldReadUntilQuitCommand(params string[] input)
        {
            // Arange
            var reader = new Mock<IReader>();

            reader.SetupSequence(r => r.ReadLine())
                                    .Returns(input[0])
                                    .Returns(input[1])
                                    .Returns(input[2])
                                    .Returns(input[3])
                                    .Returns(input[4]);
            
            var sut = new PersonSorter();

            // Act
            sut.Read(reader.Object);

            // Assert
            reader.Verify(r => r.ReadLine(), Times.Exactly(4));
        } 
    }
}
