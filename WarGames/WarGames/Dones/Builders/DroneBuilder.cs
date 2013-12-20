namespace Drones.Builders
{
    public class DroneBuilder : IDroneBuilder
    {
        public IDrone Create()
        {
            return new Drone();
        }
    }
}