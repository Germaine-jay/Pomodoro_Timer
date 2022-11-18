using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;

namespace pomodotimer
{
    internal class Program
    {

        public static int completedSession;
        public static DateTime startTime = DateTime.Now;

        static Program()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"your start time is {startTime}");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter break duration: ");
            var breakDuration = int.Parse(Console.ReadLine());

            Console.Write("Enter working duration: ");
            var workDuration = int.Parse(Console.ReadLine());

            Program.pomodoroTimer(workDuration, breakDuration);
            Program.BreakSession(breakDuration);
           
        }
        public static void BreakSession(int duration)
        {
            var braketimeDuration = duration * 1000;
            Stopwatch breaksession = new Stopwatch();
            breaksession.Start();
            Thread.Sleep(braketimeDuration);
            breaksession.Stop();
        }

        public static int pomodoroTimer(int numberOfSessions, int breakDuration)
        {

            int i = 1;
            while(i <= numberOfSessions)
            {

                Stopwatch session = new Stopwatch();
                session.Start();
                Thread.Sleep(20000);
                session.Stop();
                completedSession++;

                i++;
                if (numberOfSessions > 1)
                {

                    if(completedSession > 1)
                    {
                        Console.WriteLine($"Great, You just completed another session count:({completedSession})\n");
                        Console.WriteLine("Take a break\n");
                    }

                    else if(completedSession == 1)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"You just completed your first session\n");
                        Console.WriteLine("you can take a break now\n");
                    }
                    
                    Program.BreakSession(breakDuration);
                }

                else if (i == numberOfSessions)
                {
                    Console.WriteLine(" Total session completed");
                }
                
                TimeSpan timeSpan = session.Elapsed;
                string timeElapsed = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                Console.WriteLine($"\n Awesome, you just completed {completedSession} session in {timeElapsed}");
                Console.WriteLine($"Current time- {startTime}");

            }

            return completedSession;
        }


    }
}
