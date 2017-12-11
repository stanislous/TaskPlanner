using System;

namespace Assignment
{  
    public class Program
    {
        static void Main(string[] args)
        {
            TaskPlanner taskPlanner = new TaskPlanner();

            //Set time Span to get Work hours
            TimeSpan workdayStartTime = new TimeSpan(8, 0, 0);
            TimeSpan workdayStopTime = new TimeSpan(16, 0, 0);
           
            //send start time and end times to the TaskPlanner
            taskPlanner.setWorkdayStartTime(workdayStartTime);
            taskPlanner.setWorkdayStopTime(workdayStopTime);

            //Return Work day Hours
            double workDayHours = taskPlanner.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime);

            //Can be get the day
            DateTime dateTime = new DateTime(2004, 5, 24, 18, 3, 0);

            Console.WriteLine("For Minus :" + taskPlanner.GetTaskFinishingDate(dateTime, -5.5 * workDayHours));
            Console.ReadKey();
        }
    }
}
