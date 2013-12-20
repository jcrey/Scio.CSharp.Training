using Drones.Builders;

namespace Drones
{
    public interface IContext
    {
        IArena Arena { get; set; }
        IDrone LatestDrone { get; set; }

        IArenaBuilder ArenaBuilder { get; }
        IDroneBuilder DroneBuilder { get; }
    }
}