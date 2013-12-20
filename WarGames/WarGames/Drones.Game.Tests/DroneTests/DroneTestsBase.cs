using Moq;
using NUnit.Framework;

namespace Drones.Tests.DroneTests
{
    public class DroneTestsBase
    {
        protected Mock<IArena> arena;
        protected Drone drone;
        protected const uint upperCoordinate = 5;
        protected const uint validCoordinate = 3;
        protected const uint invalidCoordinate = 10;

        [SetUp]
        public virtual void Setup()
        {
            this.arena = new Mock<IArena>();
            this.arena.SetupGet(a => a.UpperLatitude).Returns(upperCoordinate);
            this.arena.SetupGet(a => a.UpperLongitude).Returns(upperCoordinate);

            this.drone = new Drone();
        }
    }
}