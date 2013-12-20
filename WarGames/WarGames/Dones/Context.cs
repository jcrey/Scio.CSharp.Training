using Drones.Builders;

namespace Drones
{
    public class Context : IContext
    {
        public Context(IArenaBuilder arenaBuilder, IDroneBuilder droneBuilder)
        {
            ArenaBuilder = arenaBuilder;
            DroneBuilder = droneBuilder;
        }

        public IArenaBuilder ArenaBuilder { get; private set; }
        public IDroneBuilder DroneBuilder { get; private set; }

        public IArena Arena { get; set; }
        public IDrone LatestDrone { get; set; }
    }   
}
