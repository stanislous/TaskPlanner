using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{  
    class Program
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
            DateTime dateTime = new DateTime(2017, 12, 4, 15, 7, 0);
            //Console.WriteLine(dateTime);
            //Console.ReadKey();

            Console.WriteLine(taskPlanner.GetTaskFinishingDate(dateTime, 0.25 * workDayHours));
            //Console.ReadKey();
            taskPlanner.addHolidays();
        }
    }
}
