using System.Diagnostics;

namespace Daily_0010
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Scheduler scheduler = new Scheduler())
            {
                scheduler.AddTask((() => WriteToDebug("This is the first task")), 1);
                scheduler.AddTask((() => WriteToDebug("This is the second task")), 2000);
                scheduler.AddTask((() => WriteToDebug("This is the third task")), 3000);
                scheduler.AddTask((() => WriteToDebug("This is the fifth task")), 5000);
                scheduler.AddTask((() => WriteToDebug("This is the fourth task")), 4000);
                scheduler.AddTask((() => WriteToDebug("This is the sixth task")), 6000);
            }
        }

        public static void WriteToDebug(string output)
        {
            Debug.WriteLine(output);
        }
    }
}