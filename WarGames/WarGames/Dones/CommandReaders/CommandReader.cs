using System.Text.RegularExpressions;
using Drones.Loggers;

namespace Drones.CommandReaders
{
    public abstract class CommandReader : ICommandReader
    {
        protected readonly IContext context;
        protected readonly ILogger logger;
        private readonly Regex regex;

        /// <summary>
        /// Initialize a command reader with a regular 
        /// expression pattern that defines a valid command
        /// </summary>
        protected CommandReader(string pattern, IContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
            this.regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public bool Validate(string command)
        {
            return this.regex.IsMatch(command);
        }

        public bool Validate(string command, out Match match)
        {
            match = this.regex.Match(command);
            return match.Success;
        }

        public abstract void Process(string command);
    }
}