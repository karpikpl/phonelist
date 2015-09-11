using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KattisSolution.Tests
{
    [TestFixture]
    [Category("sample")]
    public class CustomTest
    {
        [Test]
        public void SampleTest_WithStringData_Should_Pass()
        {
            // Arrange
            const string expectedAnswer = "NO\n";
            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("1\n3\n91125426\n9762599\n97625999")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass2()
        {
            // Arrange
            const string expectedAnswer = "YES\n";
            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("1\n3\n1\n2\n0")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass3()
        {
            // Arrange
            const string expectedAnswer = "NO\n";
            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("1\n3\n01\n2\n0")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass4()
        {
            // Arrange
            const string inputString = "1\n5\n0012345678\n0012345679\n0012345670\n0012355670\n0012355678";
            CollectionAssert.AllItemsAreUnique(inputString.Split('\n').Select(int.Parse));
            const string expectedAnswer = "YES\n";
            using (var input = new MemoryStream(Encoding.UTF8.GetBytes(inputString)))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void SampleTest_WithStringData_Should_Pass_When_AllNumbers()
        {
            // Arrange
            const string expectedAnswer = "YES\n";

            using (var input = new MemoryStream())
            using (var output = new MemoryStream())
            {
                var startingBuffer = Encoding.UTF8.GetBytes("1\n10000\n");
                input.Write(startingBuffer, 0, startingBuffer.Length);
                for (int i = 1000000000; i < 1000000000 + 10000; i++)
                {
                    input.Write(Encoding.UTF8.GetBytes(i + "\n"), 0, 11);
                }
                input.Seek(0, SeekOrigin.Begin);
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }
    }
}
