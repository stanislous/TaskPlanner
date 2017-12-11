using System;
using Assignment;
using NUnit.Framework;

namespace AssigmentTest
{
    [TestFixture]
    public class UnitTest1
    {
        private TaskPlanner _sut;
        //  private Program _psut;

        TimeSpan workdayStartTime = new TimeSpan(8, 0, 0);
        TimeSpan workdayStopTime = new TimeSpan(16, 0, 0);
        [SetUp] //
        public void setup()
        {
            _sut = new TaskPlanner();
            _sut.setWorkdayStartTime(workdayStartTime);
            _sut.setWorkdayStopTime(workdayStopTime);
        }
    /*    
        [Test]
        public void AddWorkingHours_WithoutHolidaysAndPoyaDays_ReturnDateAndTime()
        {
            //Arrange
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 5, 9, 7, 0);
            var dateTime = new DateTime(2017, 12, 4, 15, 7, 0);

            //Act
            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            //Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_WithHolidays_ReturnDateAndTimeAvoidingSundayAndSaturday()
        {

            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 11, 9, 7, 0);
            var dateTime = new DateTime(2017, 12, 8, 15, 7, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderInAHoliday_ReturnDateAndTimeAvoidingSundayAndSaturday()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 11, 9, 7, 0);
            var dateTime = new DateTime(2017, 12, 8, 15, 7, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderOnSaturday_ReturnDateAndTimeAvoidingSunday()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 11, 10, 0, 0);
            var dateTime = new DateTime(2017, 12, 9, 15, 7, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderBeforeAPublicHoliday_ReturnDateAndTimeAvoidingPublicHoliday()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 26, 9, 7, 0);
            var dateTime = new DateTime(2017, 12, 22, 15, 7, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderBefreAPublicHoliday_ReturnDateAndTimeAvoidingPublicHoliday()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2004, 6, 10, 14, 18, 0);
            var dateTime = new DateTime(2004, 5, 24, 8, 3, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 12.782709 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderEarlyInTheMorning_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 4, 10, 0, 0);
            var dateTime = new DateTime(2017, 12, 4, 2, 30, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderInMidNight_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 5, 10, 0, 0);
            var dateTime = new DateTime(2017, 12, 4, 22, 30, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderOnAGivenHoliday_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2004, 5, 18, 10, 0, 0);
            var dateTime = new DateTime(2004, 5, 17, 15, 7, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWorkingHours_OrderAt8AndFinishedAt4_ReturnSameDate()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 11, 16, 0, 0);
            var dateTime = new DateTime(2017, 12, 11, 8, 0, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 1 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWrkingHours_SampleTestCase1_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2004, 6, 4, 10, 12, 0);
            var dateTime = new DateTime(2004, 5, 24, 7, 3, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 8.276628 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWrkingHours_SampleTestCase2_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2004, 7, 27, 13, 47, 0);
            var dateTime = new DateTime(2004, 5, 24, 19, 3, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, 44.723656 * workDayHours);

            Assert.AreEqual(expected, result);
        }
       */ 
        
        ////------------------For Minus Cases---------------------////
        [Test]
        public void SubstractWrkingHours_WithoutHolidaysAndPoyaDays_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 5, 13, 7, 0);
            var dateTime = new DateTime(2017, 12, 5, 15, 7, 0);

            var result = _sut.GetTaskFinishingDateForMinus(dateTime, -0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void SubstractWrkingHours_OrderAt8AndFinishedAt4_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 5, 8, 0, 0);
            var dateTime = new DateTime(2017, 12, 5, 16, 0, 0);

            var result = _sut.GetTaskFinishingDateForMinus(dateTime, -1 * workDayHours);

            Assert.AreEqual(expected, result);
        }
       [Test]
        public void AddWrkingHours_OrderAtMidNight_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 5, 14, 0, 0);
            var dateTime = new DateTime(2017, 12, 5, 22, 0, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, -0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWrkingHours_OrderEarlyInTheMorning_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 4, 14, 0, 0);
            var dateTime = new DateTime(2017, 12, 5, 4, 0, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, -0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddWrkingHours_WithHolidays_ReturnDateAndTime()
        {
            var workDayHours = _sut.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);
            var expected = new DateTime(2017, 12, 1, 15, 3, 0);
            var dateTime = new DateTime(2017, 12, 4, 9, 7, 0);

            var result = _sut.GetTaskFinishingDate(dateTime, -0.25 * workDayHours);

            Assert.AreEqual(expected, result);
        }
    }
}
