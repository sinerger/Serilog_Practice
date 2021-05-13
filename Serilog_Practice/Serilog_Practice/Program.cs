using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Serilog_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = LogEventLevel.Debug;

            Logger log = new LoggerConfiguration()
                 .WriteTo.File($"log_{DateTime.Now.ToString("dd_MM__hh_mm_ss")}.txt")
                 .MinimumLevel.ControlledBy(levelSwitch)
                 .CreateLogger();

            log.Debug("Come bag");
            log.Information($"{DateTime.Now.ToString()}");
            log.Error($"{new ArgumentException().ToString()}");

            levelSwitch.MinimumLevel = LogEventLevel.Error;

            log.Debug("Come bag");
            log.Information($"{DateTime.Now.ToString()}");
            log.Error($"{new ArgumentException().ToString()}");

            Console.WriteLine("Serilog test");
        }
    }
}
