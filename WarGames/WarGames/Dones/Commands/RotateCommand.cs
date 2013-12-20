using System;
using System.Globalization;

namespace Drones.Commands
{
    public class RotateCommand : ICommand
    {
        private const string rightCommand = "R";
        private const string leftCommand = "L";

        public bool Execute(char command, IDrone drone)
        {
            if (!this.IsValid(command))
            {
                return false;
            }

            this.ProcessCommand(command, drone);
            return true;
        }

        private void ProcessCommand(char command, IDrone drone)
        {
            string commandAsString = command.ToString(CultureInfo.InvariantCulture);
            if (this.IsLeftCommand(commandAsString))
            {
                drone.Rotate(false);
            }

            if (this.IsRightCommand(commandAsString))
            {
                drone.Rotate(true);
            }
        }

        private bool IsRightCommand(string command)
        {
            return command.Equals(rightCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsLeftCommand(string command)
        {
            return command.Equals(leftCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsValid(char command)
        {
            string commandAsString = command.ToString(CultureInfo.InvariantCulture);
            return this.IsLeftCommand(commandAsString) 
                || this.IsRightCommand(commandAsString);
        }
    }
}