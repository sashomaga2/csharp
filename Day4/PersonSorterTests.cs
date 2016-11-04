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
        public void ReadShouldReadLinesUntilQuitCommand(params string[] input)
        {
            // Arrange
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

        [Test]
        [TestCase("Pesho//34", "George//10", "Ivan//55", "quit")]
        public void SortByNameLengthAndExcludeMinAge(params string[] input)
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            reader.SetupSequence(r => r.ReadLine())
                                    .Returns(input[0])
                                    .Returns(input[1])
                                    .Returns(input[2])
                                    .Returns(input[3]);

            var sut = new PersonSorter();

            // Act
            sut.Read(reader.Object);
            sut.Sort();
            sut.Write(writer.Object);

            // Assert
            //writer.Verify(r => r.WriteLine, Times.Exactly(4));
        } 
    }
}
