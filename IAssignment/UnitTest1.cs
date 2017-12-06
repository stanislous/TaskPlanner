using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;

using NUnit.Framework;

namespace AssigmentTest
{
    [TestFixture]
    public class UnitTest1
    {
        private TaskPlanner _sut;

        [SetUp] //
        public void setup()
        {
            _sut = new TaskPlanner();
        }
        [Test]
        public void DateTime_NoMoreThanTwentyFour_WrongDate()
        {
            //Arrange
          //  var numbers = "3,2,1";
           // var expected = new List<int> { 1, 2, 3 };

            //Act
           // var result = _sut.Sort(numbers);

            //Assert
            //Assert.AreEqual(expected, result);
            //Assert.AreEqual(result.Count, 3);
            //Assert.AreEqual(result[0], 1);
            //Assert.AreNotEqual(result[0], 2);
        }
    }
}
