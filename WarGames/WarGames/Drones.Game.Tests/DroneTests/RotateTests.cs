using Moq;
using NUnit.Framework;
using Drones.Enums;

namespace Drones.Tests.DroneTests
{
    [TestFixture]
    public class RotateTests : DroneTestsBase
    {
        private void SetDirection(DroneDirection direction)
        {
            this.drone.EnterArena(this.arena.Object, 0, 0, direction);
        }

        [Test]
        public void Rotate_DroneFacingNorth_DroneFacingEast()
        {
            //Arrange
            this.SetDirection(DroneDirection.North);
            
            //Act
            drone.Rotate();

            //Assert
            Assert.AreEqual(DroneDirection.East, drone.Direction);
        }

        [Test]
        public void Rotate_DroneFacingEast_DroneFacingSouth()
        {
            //Arrange
            this.SetDirection(DroneDirection.East);

            //Act
            drone.Rotate();

            //Assert
            Assert.AreEqual(DroneDirection.South, drone.Direction);
        }

        [Test]
        public void Rotate_DroneFacingSouth_DroneFacesWest()
        {
            //Arrange
            this.SetDirection(DroneDirection.South);

            //Act
            drone.Rotate();

            //Assert
            Assert.AreEqual(DroneDirection.West, drone.Direction);
        }

        [Test]
        public void Rotate_DroneFacingWest_DroneFacesNorth()
        {
            //Arrange
            this.SetDirection(DroneDirection.West);

            //Act
            drone.Rotate();

            //Assert
            Assert.AreEqual(DroneDirection.North, drone.Direction);
        }

        [Test]
        public void RotateAnticlockwise_DroneFacingNorth_DroneFacesWest()
        {
            //Arrange
            this.SetDirection(DroneDirection.North);

            //Act
            drone.Rotate(false);

            //Assert
            Assert.AreEqual(DroneDirection.West, drone.Direction);
        }

        [Test]
        public void RotateAnticlockwise_DroneFacingEast_DroneFacesNorth()
        {
            //Arrange
            this.SetDirection(DroneDirection.East);

            //Act
            drone.Rotate(false);

            //Assert
            Assert.AreEqual(DroneDirection.North, drone.Direction);
        }
    }
}
