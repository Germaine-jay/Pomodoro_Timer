using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Globalization;

namespace pomodotimer
{
    internal class Program
    {

        private static int completedSession;
        private static DateTime startTime = DateTime.Now;

        static Program()
        {
            Console.Write("Enter 'q' to exit: ");

            Console.WriteLine("your start time is {0}",startTime);
        }

        static void Main(string[] args)
        {

            Console.Write("Enter break duration: ");
            var breakDuration = int.Parse(Console.ReadLine());

            Console.Write("Enter working duration: ");
            var workDuration = int.Parse(Console.ReadLine());

            Program.TaskTimer(workDuration, breakDuration);
            Program.BreakSession(breakDuration);
           
        }
        static void BreakSession(int duration)
        {
            var brakeTimeDuration = duration * 1000;
            Stopwatch breaksession = new Stopwatch();
            breaksession.Start();
            Thread.Sleep(brakeTimeDuration);
            breaksession.Stop();
        }

        static int TaskTimer(int workDuration, int breakDuration)
        {

            int i = 1;
            int numberOfSessions = 0;

            while (true)
            {

                int workingTime = workDuration * 10000;

                Stopwatch session = new Stopwatch();
                session.Start();
                Thread.Sleep(workingTime);
                session.Stop();
                Console.Beep();
                completedSession++;                
                i++;

                if (numberOfSessions > 1)
                {
                    if (completedSession > 1)
                    {
                        Console.WriteLine("Great, You just completed another session count:{0} \n Take a break", completedSession);
                    }

                    else if (completedSession == 1)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You just completed your first session\n You can take a break now");
                    }

                    Program.BreakSession(breakDuration);
                }

                else if (i == numberOfSessions)
                {
                    Console.WriteLine("Total session completed");
                }

                TimeSpan SessionTimeSpan = session.Elapsed;
                string timeElapsed = String.Format("{0:00}:{1:00}:{2:00}", SessionTimeSpan.Hours, SessionTimeSpan.Minutes, SessionTimeSpan.Seconds);

                Console.WriteLine("\nAwesome, you just completed {0} sessions in {1}", completedSession, timeElapsed);
                Console.WriteLine("Current time-{0}", startTime);

                return completedSession;
                
            }
        }
    }
}
