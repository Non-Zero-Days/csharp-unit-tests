using Microsoft.VisualStudio.TestTools.UnitTesting;
using src;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Class1_PrependNonZero_Given_Day_Prepends_NonZero()
        {
            // Arrange
            var input = "Day";
            var expected = "NonZero Day";
            var testableClass = new Class1();

            // Act
            var actual = testableClass.PrependNonZero(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
