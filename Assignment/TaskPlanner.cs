using System;

namespace Assignment
{
    public class TaskPlanner
    {
        private TimeSpan startTime;
        private TimeSpan stopTime;
        public double time_difference;
        public TimeSpan hourMinute;
        public double SetWorkdayStartAndStop(TimeSpan startTime, TimeSpan stopTime)
        {
            TimeSpan TimeD;
            TimeD = stopTime - startTime;

            double timeDiffernce = (double)TimeD.TotalHours;
            time_difference = timeDiffernce;
            
            return timeDiffernce;
        }
        public DateTime GetTaskFinishingDate(DateTime start, double hours)
        { 
            TimeSpan interval;
            int h = start.Hour;
            int m = start.Minute;
            hourMinute = new TimeSpan(h, m, 0);  //15:07

            //for Minus Cases
            if (hours < 0) start = GetTaskFinishingDateForMinus(start, hours);
            //For Plus
            else
            {
                if (addHolidays(start) == 1)
                {
                    start = start.AddDays(1);
                    start = codeRedundency(start);
                }
                else if (addHolidays(start) == 2)
                {
                    start = start.AddDays(2);
                    start = codeRedundency(start);
                }

                //if order comes at night
                if (hourMinute.CompareTo(stopTime) > 0)
                {
                    start = new DateTime(start.Year, start.Month, start.Day + 1, 8, 0, 0);
                }
                //if order comes at early morning
                else if (hourMinute.CompareTo(startTime) < 0)
                {
                    start = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                }

                int addingDays = (int)hours / (int)time_difference; //days that added 
                double addingHours = hours % time_difference; //hours that added 
                interval = TimeSpan.FromHours(hours);

                if (addingDays == 1 && addingHours == 0)
                { //if order at 8 and finished at 4
                    addingDays = 0;
                    addingHours = time_difference;
                }

                if (h > stopTime.Hours || h < startTime.Hours)
                {
                    hourMinute = new TimeSpan(startTime.Hours, startTime.Minutes, 0);
                }

                if ((hourMinute.Hours + addingHours).CompareTo(stopTime.Hours) > 0)
                {
                    start = start.AddDays(1);
                    start = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                    interval = interval - (stopTime - hourMinute);
                    addingHours = interval.TotalHours;
                    if (start.DayOfWeek == DayOfWeek.Saturday && addingDays == 0) start = start.AddDays(2);
                    if (start.DayOfWeek == DayOfWeek.Sunday && addingDays == 0) start = start.AddDays(1);
                    if (addHolidays(start) == 1) start = start.AddDays(1);
                }

                // start = start.AddDays(addingDays);
                while (addingDays != 0)
                {
                    if (addHolidays(start) == 0)
                    {
                        start = start.AddDays(1);
                        addingDays--;
                    }
                    else if (addHolidays(start) == 2)
                    {
                        start = start.AddDays(2);
                    }
                  /*  else if (addHolidays(start) == 3 || addHolidays(start) == 1)
                    {
                        start = start.AddDays(1);
                    }*/
                }
                
                start = start.AddHours(addingHours);
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, 0);
            }
            return start;
        }

        public DateTime codeRedundency(DateTime start)
        {
            start = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
            int h = startTime.Hours;
            int m = startTime.Minutes;
            TimeSpan hourM = new TimeSpan(h, m, 0);
            hourMinute = hourM;
            return start;
        }

        public double getWorkDayHours(double hours) { return hours; }
        //Getting the start and stop times in hours and minutes
        public void setWorkdayStartTime(TimeSpan startTime) { this.startTime = startTime; }//.ToString(@"hh\:mm")
        public void setWorkdayStopTime(TimeSpan stopTime) { this.stopTime = stopTime; }
        private TimeSpan getWorkdayStartTime() { return startTime; }
        private TimeSpan getWorkdayStopTime() { return stopTime; }

        public int addHolidays(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Sunday || addSelectedHolidays(day,day.Year) == 1) { return 1; }
            else if(day.DayOfWeek == DayOfWeek.Saturday) { return 2; }
            return 0;
        }
        public int addSelectedHolidays(DateTime date, int year)
        {
            DateTime Recurent = new DateTime(2004, 5, 17);
            DateTime Normal = new DateTime(2004, 5, 27);
            DateTime Xmas = new DateTime(year, 12, 25);
            // && Recurent.Month == date.Month && Recurent.Day == date.Day || Normal.Year == date.Year && Normal.Month == date.Month && Normal.Day == date.Day
            if (Recurent.ToString("dd/MM/yyyy") == date.ToString("dd/MM/yyyy") || Normal.ToString("dd/MM/yyyy") == date.ToString("dd/MM/yyyy") || Xmas.ToString("dd/MM/yyyy") == date.ToString("dd/MM/yyyy")) return 1;
            else return 0;
        }
                          /////////////////////////////////////////////
 //////////////////////////----------------For Minus-------------------///////////////////////////
                          /////////////////////////////////////////////

        public DateTime GetTaskFinishingDateForMinus(DateTime start, double hours)
        {
            TimeSpan interval;
            int h = start.Hour;
            int m = start.Minute;
            hourMinute = new TimeSpan(h, m, 0);  //15:07

            if (addHolidaysForMinus(start) == 1 )
            {
                start = start.AddDays(-1);
                start = codeRedundencyForMinus(start);
            }
            else if (addHolidaysForMinus(start) == 2)
            {
                start = start.AddDays(-2);
                start = codeRedundencyForMinus(start);
            }

            //if order comes at night
            if (hourMinute.CompareTo(stopTime) > 0)
            {
                start = new DateTime(start.Year, start.Month, start.Day, 16, 0, 0);
            }
            //if order comes at early morning
            else if (hourMinute.CompareTo(startTime) < 0)
            {
                start = new DateTime(start.Year, start.Month, start.Day-1, 16, 0, 0);
            }

            int substractingDays = (int)hours / (int)time_difference; //days that added 
            double substractingHours = hours % time_difference; //hours that added 
            interval = TimeSpan.FromHours(hours);


            if (substractingDays == -1 && substractingHours == 0)
            { //if order at 16 and finished at 8
                substractingDays = 0;
                substractingHours = -time_difference;
            }

            if (h > stopTime.Hours || h < startTime.Hours)
            {
                hourMinute = new TimeSpan(stopTime.Hours, stopTime.Minutes, 0);
            }

            if ((hourMinute.Hours + substractingHours).CompareTo(startTime.Hours) < 0)
            {
                start = start.AddDays(-1);
                start = new DateTime(start.Year, start.Month, start.Day, 16, 0, 0);
                interval = interval + (hourMinute - startTime) ;
                substractingHours = interval.TotalHours;
                if (start.DayOfWeek == DayOfWeek.Sunday && substractingDays == 0) start = start.AddDays(-2);
                if (start.DayOfWeek == DayOfWeek.Saturday && substractingDays == 0) start = start.AddDays(-1);
                if (addHolidaysForMinus(start) == 1) start = start.AddDays(-1);
            }

            // start = start.AddDays(addingDays);
            
            while (substractingDays != 0)
            {
                if (addHolidaysForMinus(start) == 0)
                {
                    start = start.AddDays(-1); 
                    substractingDays++;
                }
                else if (addHolidaysForMinus(start) == 2)
                {
                    start = start.AddDays(-2);
                }
                else if (addHolidaysForMinus(start) == 3 || addHolidaysForMinus(start) == 1)
                {
                    start = start.AddDays(-1);
                }
            }
            if(addSelectedHolidays(start,start.Year) == 1) start = start.AddDays(-1);
            start = start.AddHours(substractingHours);
            start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, 0);
            return start;
        }
        public int addHolidaysForMinus(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Saturday || addSelectedHolidays(day, day.Year) == 1) { return 1; }
            else if (day.DayOfWeek == DayOfWeek.Sunday) { return 2; }
            return 0;
        }
        public DateTime codeRedundencyForMinus(DateTime start)
        {
            start = new DateTime(start.Year, start.Month, start.Day, 16, 0, 0);
            int h = stopTime.Hours;
            int m = stopTime.Minutes;
            TimeSpan hourM = new TimeSpan(h, m, 0);
            hourMinute = hourM;
            return start;
        }
    }
}










/*
Console.WriteLine();
Console.ReadKey();

 //   CountryCode a = new CountryCode();
             //   a = CountryCode.US;
*/
