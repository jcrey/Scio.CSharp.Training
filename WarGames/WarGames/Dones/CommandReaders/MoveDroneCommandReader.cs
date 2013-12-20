using System.Collections.Generic;
using System.Linq;
using Drones.Commands;
using Drones.Loggers;

namespace Drones.CommandReaders
{
    public class MoveDroneCommandReader : CommandReader
    {
        private readonly IList<ICommand> commands;

        public MoveDroneCommandReader(IContext context, IEnumerable<ICommand> commands, ILogger logger )
            : base("^[m|r|l]+$", context, logger)
        {
            this.commands = commands.ToList();
        }

        public override void Process(string command)
        {
            if (!this.Validate(command))
            {
                return;
            }

            IDrone drone = this.context.LatestDrone;
            foreach (var character in command.ToLowerInvariant())
            {
                ICommand executer = GetExecuter(character);
                executer.Execute(character, drone);
            }

            this.logger.Log("drone movement completed");
            this.logger.Log(string.Format("drone Position: {0} {1} {2}", drone.Latitude, drone.Longitude, drone.Direction));
        }

        private ICommand GetExecuter(char character)
        {
            return this.commands.FirstOrDefault(command => command.IsValid(character));
        }
    }
}