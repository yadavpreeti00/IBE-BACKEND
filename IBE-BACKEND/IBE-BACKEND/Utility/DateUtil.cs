using System;

namespace IBE_BACKEND.Utility
{
    public static class DateUtil
    {
        public static long GetDaysInBetween(string selectedStartDate, string selectedEndDate)
        {
            DateTime startDate = Convert.ToDateTime(selectedStartDate);
            DateTime endDate = Convert.ToDateTime(selectedEndDate);

            if (startDate > endDate)
            {
                throw new ArgumentException("Invalid date range.");
            }

            return (endDate - startDate).Days + 1;
        }

        public static bool CheckWeekend(string selectedStartDate, string selectedEndDate, string weekendCheckType)
        {

            DateTime startDate = DateTime.Parse(selectedStartDate.Split('T')[0]);
            DateTime endDate = DateTime.Parse(selectedEndDate.Split('T')[0]);

            bool hasSaturday = false;
            bool hasSunday = false;

            for (DateTime date = startDate; date.Date.CompareTo(endDate.Date) <= 0; date = date.AddDays(1))
            {
                // Check if the current day is a Saturday or Sunday
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    hasSaturday = true;
                }
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    hasSunday = true;
                }

                // Exit the loop as soon as both Saturday and Sunday are found
                if (hasSaturday && hasSunday)
                {
                    break;
                }
            }

            if ("allWeekend".Equals(weekendCheckType, StringComparison.OrdinalIgnoreCase))
            {
                return hasSaturday && hasSunday;
            }
            else
            {
                return hasSaturday || hasSunday;
            }
        }

        public static DateTime ConvertToDate(string dateString)
        {
            DateTime date;
            try
            {
                date = DateTime.Parse(dateString.Split('T')[0]);
                return date.Date;
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Invalid date", e);
            }
        }

    }
}
