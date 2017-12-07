using System;
using Nager.Date;

namespace Assignment
{
    public class TaskPlanner
    {
        private TimeSpan startTime;
        private TimeSpan stopTime;
        public double time_difference;
        public int i = 0;

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
            TimeSpan hourMinute;
            TimeSpan interval;
            DateTime beforeDateTime;
            DateTime afterDateTime;

            int h = start.Hour;
            int m = start.Minute;

            hourMinute = new TimeSpan(h, m, 0);  //15:07
            beforeDateTime = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);

          
            start = isHoliday(beforeDateTime);
            beforeDateTime = start;

            if (hourMinute.CompareTo(stopTime) > 0)  //if order comes at night
            {
                DateTime a = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                start = a;
                start = start.AddDays(1);
            }
            else if (hourMinute.CompareTo(startTime) < 0)  //if order comes at early morning
            {
                DateTime a = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                start = a;
            }

            int addingDays = (int)hours / (int)time_difference; //days that added 
            double addingHours = hours % time_difference; //hours that added (same thing sa interval)
            interval = TimeSpan.FromHours(hours);  //2 hours wada krna welawa paya walin

            if (h > stopTime.Hours || h < startTime.Hours || i > 0)
            {
                h = startTime.Hours;
                m = startTime.Minutes;
                TimeSpan hourM = new TimeSpan(h, m, 0);
                hourMinute = hourM;
            }

            if ((hourMinute + interval).CompareTo(stopTime) > 0)
            {
                //start = start.AddHours(24 - time_difference);
                start = start.AddDays(1);
                DateTime a = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                start = a;
                interval = interval - (stopTime - hourMinute);
                addingHours = interval.TotalHours;
            } 
        
            start = start.AddDays(addingDays);
            start = start.AddHours(addingHours);
            afterDateTime = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);//2017, 4, 12, 15, 7, 0
            // Console.WriteLine("Before Holidays added: " + start);
            start = addHolidays(beforeDateTime, afterDateTime);
            //Console.WriteLine("After Holidays added: " + start); 
            return start;
        }

        public double getWorkDayHours(double hours) { return hours; }
        //Getting the start and stop times in hours and minutes
        public void setWorkdayStartTime(TimeSpan startTime) { this.startTime = startTime/*.ToString(@"hh\:mm")*/; }
        public void setWorkdayStopTime(TimeSpan stopTime) { this.stopTime = stopTime/*.ToString(@"hh\:mm")*/; }
        private TimeSpan getWorkdayStartTime() { return startTime; }
        private TimeSpan getWorkdayStopTime() { return stopTime; }

        public DateTime addHolidays(DateTime beforeDateTime, DateTime afterDateTime)
        {
            CountryCode a = new CountryCode();
            a = CountryCode.NO;
            DateTime newDate = afterDateTime;
           
            if (afterDateTime.DayOfWeek == DayOfWeek.Sunday) { afterDateTime = afterDateTime.AddDays(1); }
            if (afterDateTime.DayOfWeek == DayOfWeek.Saturday) { afterDateTime = afterDateTime.AddDays(2); }
            if (DateSystem.IsPublicHoliday(afterDateTime, a)) { afterDateTime = afterDateTime.AddDays(1); }

            while (beforeDateTime.Day != afterDateTime.Day)
            {
                
                if (beforeDateTime.DayOfWeek == DayOfWeek.Sunday || beforeDateTime.DayOfWeek == DayOfWeek.Saturday || DateSystem.IsPublicHoliday(beforeDateTime, a))
                {
                    //Console.WriteLine(beforeDateTime);
                    newDate = newDate.AddDays(1);   
                }
                beforeDateTime = beforeDateTime.AddDays(1);
            }
            //Console.ReadKey();
            return newDate;
        }
        public DateTime isHoliday(DateTime beforeDateTime)
        {
            if (beforeDateTime.DayOfWeek == DayOfWeek.Sunday) {
                beforeDateTime = beforeDateTime.AddDays(1);
                DateTime a = new DateTime(beforeDateTime.Year, beforeDateTime.Month, beforeDateTime.Day, 8, 0, 0);
                beforeDateTime = a;
                i++;
            }
            if (beforeDateTime.DayOfWeek == DayOfWeek.Saturday) {
                beforeDateTime = beforeDateTime.AddDays(2);
                DateTime a = new DateTime(beforeDateTime.Year, beforeDateTime.Month, beforeDateTime.Day, 8, 0, 0);
                beforeDateTime = a;
                i++;
            }

            return beforeDateTime;
        }
    }
}