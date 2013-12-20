using System;

namespace Drones.Enums
{
    [Flags]
    public enum DroneDirection
    {
        North = 1,
        East = 2,
        South = 4,
        West = 8
    }
}