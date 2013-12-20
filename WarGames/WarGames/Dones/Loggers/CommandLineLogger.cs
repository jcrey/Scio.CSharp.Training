using System;

namespace Drones.Loggers
{
    public class CommandLineLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("LOG: {0}", message);
        }
    }
}