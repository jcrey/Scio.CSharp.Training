using Drones.Enums;

namespace Drones
{
    public class Drone : IDrone
    {
        public Drone()
        {
            this.Direction = DroneDirection.North;
        }

        public DroneDirection Direction { get; private set; }
        public uint Latitude { get; private set; }
        public uint Longitude { get; private set; }
        public IArena Arena { get; set; }

        /// <summary>
        /// Move drone forward 1 unit
        /// </summary>
        public void Move()
        {
            if (this.Arena == null)
            {
                return;
            }

            switch (Direction)
            {
                case DroneDirection.North:
                    if (this.Longitude < this.Arena.UpperLongitude)
                    {
                        this.Longitude++;
                    }
                    break;
                case DroneDirection.East:
                    if (this.Latitude < this.Arena.UpperLatitude)
                    {
                        this.Latitude++;
                    }
                    break;
                case DroneDirection.South:
                    if (this.Longitude > 0)
                    {
                        this.Longitude--;                        
                    }
                    break;
                case DroneDirection.West:
                    if (this.Latitude > 0)
                    {
                        this.Latitude--;
                    }
                    break;
            }
        }

        /// <summary>
        /// Rotate the drone clockwise or anticlockwise
        /// </summary>
        public void Rotate(bool clockwise = true)
        {
            if (clockwise)
            {
                this.Direction = this.Direction == DroneDirection.West ? DroneDirection.North 
                                                                       : (DroneDirection) (((int) this.Direction) << 1);
            }
            else
            {
                this.Direction = this.Direction == DroneDirection.North ? DroneDirection.West 
                                                                        : (DroneDirection) (((int) this.Direction) >> 1);
            }
        }

        /// <summary>
        /// Enter an arena and go to a specified location 
        /// </summary>
        /// <param name="arena">Arena to enter</param>
        /// <param name="x">X coordinate (latitude)</param>
        /// <param name="y">Y coordinate (longitude)</param>
        /// <param name="direction"></param>
        /// <returns>True if arena entered successfully, otherwise false</returns>
        public bool EnterArena(IArena arena, uint x, uint y, DroneDirection direction)
        {
            if (arena == null || x > arena.UpperLatitude || y > arena.UpperLongitude)
            {
                return false;
            }

            this.Arena = arena;
            this.Latitude = x;
            this.Longitude = y;
            this.Direction = direction;

            return true;
        }
    }
}