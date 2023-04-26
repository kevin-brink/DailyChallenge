using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_0010
{
    public class Scheduler : IDisposable
    {
        Mutex mutex;
        bool kill = false;

        private List<Tuple<DateTime, Action>> schedule = new();

        private Task scheduleRunning;

        public Scheduler() 
        {
            mutex = new Mutex();
            scheduleRunning = Task.Run(RunScheduler); 
        }

        public void AddTask(Action task, int msToExecute)
        {
            try
            {
                mutex.WaitOne();
                var timeToExecute = DateTime.Now.AddMilliseconds(msToExecute);

                schedule.Add(new (timeToExecute, task));
            }
            finally { mutex.ReleaseMutex(); }
        }

        private void RunScheduler()
        {
            var startTime = DateTime.Now;
            Debug.WriteLine("Starting Scheduler at " + startTime);
            DateTime lastPrint = DateTime.Now;

            while (!kill)
            {
                try
                {
                    var toRemove = new List<int>();
                    mutex.WaitOne();
                    for (int index = 0; index < schedule.Count; ++index)
                    {
                        var task = schedule[index];
                        if (task.Item1 <= DateTime.Now)
                        {
                            Task.Run(task.Item2);
                            toRemove.Add(index);
                        }
                    }

                    toRemove.Reverse();
                    foreach (var index in toRemove)
                        schedule.Remove(schedule[index]);
                }
                finally
                {
                    mutex.ReleaseMutex();
                }

                if (lastPrint.AddSeconds(1) < DateTime.Now)
                {
                    Debug.WriteLine($"Scheduler still running at {DateTime.Now}");
                    lastPrint = DateTime.Now;
                }
            }
        }

        public void WaitUntilComplete()
        {
            while(true)
            {
                try
                {
                    mutex.WaitOne();
                    if (schedule.Count == 0)
                        return;
                }
                finally { mutex.ReleaseMutex(); }
            }
        }

        public void KillImmediately()
        {
            try
            {
                mutex.WaitOne();
                kill = true; ;
            }
            finally { mutex.ReleaseMutex(); }

            Debug.WriteLine("Scheduler was eneded without regard for remaining tasks");
        }

        public void Dispose()
        {
            WaitUntilComplete();
            Debug.WriteLine("Scheduler has successfully ended at " + DateTime.Now);
        }
    }
}
