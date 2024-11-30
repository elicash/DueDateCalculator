namespace DueDateCalculator.Services
{
    public interface ICalculator
    {
        DateTime CalculateDueDate(DateTime submitDate, int turnaroundTime);
        void ValidateSubmitDate(DateTime submitDate);
        DateTime AdvanceWorkingDate(DateTime workingDate);
        DateTime AdvanceWorkingDateToNextDay(DateTime workingDate);
        DateTime AdvanceWorkingDateToNextWeek(DateTime workingDate);
    }
}
