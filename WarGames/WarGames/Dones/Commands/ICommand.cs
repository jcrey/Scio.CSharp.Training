namespace Drones.Commands
{
    public interface ICommand
    {
        bool Execute(char command, IDrone drone);
        bool IsValid(char command);
    }
}