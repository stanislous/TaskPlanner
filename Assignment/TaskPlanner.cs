using System;
using Nager.Date;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class TaskPlanner
    {

        private TimeSpan startTime;
        private TimeSpan stopTime;
        public double time_difference;
        

        public double SetWorkdayStartAndStop(TimeSpan startTime, TimeSpan stopTime)
        {
            TimeSpan TimeD;
            TimeD = stopTime - startTime;

            double timeDiffernce = (double)TimeD.TotalHours;
            //  Console.WriteLine(timeDiffernce);
            //  Console.ReadKey();
            time_difference = timeDiffernce;

            return timeDiffernce;
        }

        public DateTime GetTaskFinishingDate(DateTime start, double hours)
        {

            //  Console.WriteLine("The Date time: " + start);
            //Console.WriteLine("The start time: " + startTime);

            TimeSpan hourMinute;
            TimeSpan interval;
            DateTime beforeDateTime;
            DateTime afterDateTime;

        int h = start.Hour; int m = start.Minute;
            hourMinute = new TimeSpan(h, m, 0);  //15:07
            beforeDateTime = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);


            if (hourMinute.CompareTo(stopTime) > 0)  //if order comes at night
            {
                DateTime a = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                start = a;
                start = start.AddDays(1);
                //Console.WriteLine(start);
                //Console.WriteLine(hourMinute.CompareTo(startTime));
                //Console.WriteLine(hourMinute.CompareTo(stopTime));
                //Console.ReadKey();

            } else if (hourMinute.CompareTo(startTime) < 0)  //if order comes at early morning
            {
                DateTime a = new DateTime(start.Year, start.Month, start.Day, 8, 0, 0);
                start = a;
            }
            

            int addingDays = (int)hours / (int)time_difference; //days that added 
            double addingHours = hours % time_difference; //hours that added
            interval = TimeSpan.FromHours(hours);  //2 hours

            if ((hourMinute + interval).CompareTo(stopTime) > 0)
            {
                start = start.AddHours(24 - time_difference);
            }
            
            // Console.WriteLine("Adding Days : " + addingDays);
            // Console.WriteLine("Adding Hours: " + addingHours);
            // Console.WriteLine("Start: " + start);
            // Console.ReadKey();

            start = start.AddDays(addingDays);
            start = start.AddHours(addingHours);
            afterDateTime = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);//2017, 4, 12, 15, 7, 0
           // Console.WriteLine("Before Holidays added: " + start);
            start = addHolidays(beforeDateTime, afterDateTime);
            //Console.WriteLine("After Holidays added: " + start); 
            return start;

        }

        public double getWorkDayHours(double hours)
        {
            return hours;
        }

        //Getting the start and stop times in hours and minutes
        public void setWorkdayStartTime(TimeSpan startTime)
        {
            this.startTime = startTime/*.ToString(@"hh\:mm")*/;
            //  Console.WriteLine(this.startTime);
            //   Console.ReadKey();
        }
        public void setWorkdayStopTime(TimeSpan stopTime) { this.stopTime = stopTime/*.ToString(@"hh\:mm")*/; }
        private TimeSpan getWorkdayStartTime() { return startTime; }
        private TimeSpan getWorkdayStopTime() { return stopTime; }

        public DateTime addHolidays(DateTime beforeDateTime, DateTime afterDateTime)
        {
            CountryCode a = new CountryCode();
            
            DateTime newDate = afterDateTime;
          //  Console.WriteLine("newDate: "+newDate);
          //  Console.ReadKey();
            if(afterDateTime.DayOfWeek == DayOfWeek.Sunday) { afterDateTime = afterDateTime.AddDays(1); }
            if (afterDateTime.DayOfWeek == DayOfWeek.Saturday) { afterDateTime = afterDateTime.AddDays(2); }

            while (beforeDateTime.Day != afterDateTime.Day)
                {
                    if (beforeDateTime.DayOfWeek == DayOfWeek.Sunday || beforeDateTime.DayOfWeek == DayOfWeek.Saturday /*|| DateSystem.IsPublicHoliday(beforeDateTime, )*/)
                    {
                        newDate = newDate.AddDays(1);
                        //Console.WriteLine("Skipped");
                    }
                    beforeDateTime = beforeDateTime.AddDays(1);
                }
                Console.WriteLine();
                Console.ReadKey();
                return newDate;
            }
        }
    }