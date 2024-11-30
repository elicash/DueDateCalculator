using DueDateCalculator.Services;

namespace DueDateCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Add test values here
            var submitDate = new DateTime(2024, 11, 11, 9, 30, 0);
            var turnaroundTime = 6;

            var calculator = new Calculator();
            calculator.ValidateSubmitDate(submitDate);
            DateTime dueDateResult = calculator.CalculateDueDate(submitDate, turnaroundTime);

            Console.WriteLine(dueDateResult.DayOfWeek.ToString() + " - Day");
            Console.WriteLine(dueDateResult.Hour.ToString() + " - Hour");
            Console.WriteLine(dueDateResult.Minute.ToString() + " - Minute");
        }
    }
}