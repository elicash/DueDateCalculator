using DueDateCalculator.Exceptions;
using DueDateCalculator.Services;

namespace DueDateCalculator.Test
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly Calculator _calculator = new();

        [TestMethod]
        public void AdvanceDateAdvancesDateWhenDayIsFriday()
        {
            var workingDate = new DateTime(2024, 11, 15, 17, 15, 0);

            var result = _calculator.AdvanceWorkingDate(workingDate);

            Assert.IsTrue(result.DayOfWeek == DayOfWeek.Monday);
        }

        [TestMethod]
        public void AdvanceDateAdvancesDateWhenDayIsWeekday()
        {
            var workingDate = new DateTime(2024, 11, 14, 17, 15, 0);

            var result = _calculator.AdvanceWorkingDate(workingDate);

            Assert.IsTrue(result.DayOfWeek == DayOfWeek.Friday);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSubmitDateException))]
        public void ValidateSubmitDateThrowsExceptionWhenTooEarly()
        {
            var submitDate = new DateTime(2024, 11, 14, 2, 15, 0);

            _calculator.ValidateSubmitDate(submitDate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSubmitDateException))]
        public void ValidateSubmitDateThrowsExceptionWhenTooLate()
        {
            var submitDate = new DateTime(2024, 11, 14, 20, 15, 0);

            _calculator.ValidateSubmitDate(submitDate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSubmitDateException))]
        public void ValidateSubmitDateThrowsExceptionWhenNotWeekday()
        {
            var submitDate = new DateTime(2024, 11, 16, 15, 15, 0);

            _calculator.ValidateSubmitDate(submitDate);
        }

        [TestMethod]
        public void CalculateDueDateReturnsSameDateWhenTurnaroundTimeIsZero()
        {
            var submitDate = new DateTime(2024, 11, 15, 12, 15, 0);
            var turnaroundTime = 0;
            var expected = submitDate;

            var result = _calculator.CalculateDueDate(submitDate, turnaroundTime);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateDueDateReturnsCorrectDueDateAndSkipsOffHours()
        {
            var submitDate = new DateTime(2024, 11, 15, 12, 15, 0);
            var turnaroundTime = 12;
            var expected = new DateTime(2024, 11, 18, 16, 15, 0);

            var result = _calculator.CalculateDueDate(submitDate, turnaroundTime);

            Assert.AreEqual(expected, result);
        }
    }
}