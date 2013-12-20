namespace Drones.Commands
{
    public class MoveCommand : ICommand
    {
        public bool Execute(char command, IDrone drone)
        {
            if (drone == null || !this.IsValid(command))
            {
                return false;
            }

            drone.Move();
            return true;
        }

        public bool IsValid(char command)
        {
            return command == 'M' || command == 'm';
        }
    }
}
