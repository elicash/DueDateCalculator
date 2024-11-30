using DueDateCalculator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Services
{
    public class Calculator : ICalculator
    {
        public DateTime CalculateDueDate(DateTime submitDate, int turnaroundTime)
        {
            var remainingTime = turnaroundTime;
            var workingDate = submitDate;

            while (workingDate.Hour < 17 && remainingTime > 0)
            {
                remainingTime -= 1;
                workingDate = workingDate.AddHours(1);
            }

            if (remainingTime > 0) {
                workingDate = AdvanceWorkingDate(workingDate);
                return CalculateDueDate(workingDate, remainingTime);
            }
            else {
                if (workingDate.Hour >= 17 && workingDate.Minute > 0) {
                    workingDate = AdvanceWorkingDate(workingDate);
                }
            }

            return workingDate;
        }

        public void ValidateSubmitDate(DateTime submitDate) {
            if (submitDate.Hour > 17)
            {
                throw new InvalidSubmitDateException();
            }
            if (submitDate.Hour >= 17 && submitDate.Minute > 0)
            {
                throw new InvalidSubmitDateException();
            }
            else if (submitDate.Hour < 9)
            {
                throw new InvalidSubmitDateException();
            }
            else if (submitDate.DayOfWeek == DayOfWeek.Sunday || submitDate.DayOfWeek == DayOfWeek.Saturday) {
                throw new InvalidSubmitDateException();
            }
        }

        public DateTime AdvanceWorkingDate(DateTime workingDate)
        {
            var newDate = new DateTime();
            if (workingDate.DayOfWeek == DayOfWeek.Friday) {
                newDate = AdvanceWorkingDateToNextWeek(workingDate);
            } else
            {
                newDate = AdvanceWorkingDateToNextDay(workingDate);
            }
            return newDate;
        }

        public DateTime AdvanceWorkingDateToNextDay(DateTime workingDate)
        {
            var newDate = workingDate;
            newDate = newDate.AddDays(1);
            newDate = newDate.AddHours(-8);
            return newDate;
        }

        public DateTime AdvanceWorkingDateToNextWeek(DateTime workingDate) {
            var newDate = workingDate;
            newDate = newDate.AddDays(3);
            newDate = newDate.AddHours(-8);
            return newDate;
        }
    }
}
