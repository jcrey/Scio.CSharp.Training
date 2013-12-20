using System;
using System.Text.RegularExpressions;
using Drones.Enums;
using Drones.Loggers;

namespace Drones.CommandReaders
{
    public class CreateDroneCommandReader : CommandReader
    {
        private const string latitudeGroupName = "Latitude";
        private const string longitudeGroupName = "Longitude";
        private const string directionGroupName = "Direction";

        private static readonly string regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[n|e|s|w])$", latitudeGroupName, longitudeGroupName, directionGroupName);

        public CreateDroneCommandReader(IContext context, ILogger logger)
            : base(regexPattern, context, logger)
        {
        }

        public override void Process(string command)
        {
            Match match;
            if (!this.Validate(command, out match))
            {
                return;
            }

            this.context.LatestDrone = this.context.DroneBuilder.Create();

            if (this.context.LatestDrone == null)
            {
                return;
            }

            uint latitude = Convert.ToUInt32(match.Groups[latitudeGroupName].Value);
            uint longitude = Convert.ToUInt32(match.Groups[longitudeGroupName].Value);
            DroneDirection direction = ConvertToDirection(match.Groups[directionGroupName].Value);

            bool droneCreated = this.context.LatestDrone.EnterArena(this.context.Arena, latitude, longitude, direction);

            string logMessage = String.Format("drone creation {0}", droneCreated ? "successful" : "failed");
            this.logger.Log(logMessage);
        }

        private DroneDirection ConvertToDirection(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "e":
                    return DroneDirection.East;
                case "s":
                    return DroneDirection.South;
                case "w":
                    return DroneDirection.West;
                default:
                    return DroneDirection.North;
            }
        }
    }
}