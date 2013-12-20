using Moq;
using NUnit.Framework;
using Drones.Enums;

namespace Drones.Tests.DroneTests
{
    [TestFixture]
    public class EnterArenaTests : DroneTestsBase
    {
        [Test]
        public void EnterArena_ValidArena_ArenaPropertySet()
        {
            //Arrange

            //Act
            drone.EnterArena(this.arena.Object, 0, 0, DroneDirection.North);

            //Assert
            Assert.AreSame(arena.Object, drone.Arena);
        }

        [Test]
        public void EnterArena_ValidXCoordinate_DroneLatitudeSet()
        {
            //Arrange

            //Act
            drone.EnterArena(this.arena.Object, validCoordinate, validCoordinate, DroneDirection.North);

            //Assert
            Assert.AreEqual(validCoordinate, drone.Latitude);

        }

        [Test]
        public void EnterArena_ValidYCoordinate_DroneLongitudeSet()
        {
            //Arrange

            //Act
            drone.EnterArena(this.arena.Object, validCoordinate, validCoordinate, DroneDirection.North);

            //Assert
            Assert.AreEqual(validCoordinate, drone.Longitude);
        }

        [Test]
        public void EnterArena_InvalidXCoordinate_ReturnFalse()
        {
            //Arrange

            //Act
            bool success = drone.EnterArena(this.arena.Object, invalidCoordinate, validCoordinate, DroneDirection.North);
            
            //Assert
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_ValidCoordinates_ReturnTrue()
        {
            //Arrange

            //Act
            bool success = drone.EnterArena(this.arena.Object, validCoordinate, validCoordinate, DroneDirection.North);

            //Assert
            Assert.IsTrue(success);
        }

        [Test]
        public void EnterArena_InvalidYCoordinate_ReturnFalse()
        {
            //Arrange

            //Act
            bool success = drone.EnterArena(this.arena.Object, validCoordinate, invalidCoordinate, DroneDirection.North);

            //Assert
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_ArenaIsNull_ReturnFalse()
        {
            //Arrange

            //Act
            bool success = drone.EnterArena(null, validCoordinate, invalidCoordinate, DroneDirection.North);

            //Assert
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_DirectionIsEast_DroneDirectionIsSet()
        {
            //Arrange
            var droneDirection = DroneDirection.East;
            
            //Act
            drone.EnterArena(this.arena.Object, validCoordinate, validCoordinate, droneDirection);

            //Assert
            Assert.AreEqual(droneDirection, drone.Direction);
        }

        [Test]
        public void EnterArena_DirectionIsSouth_DroneDirectionIsSet()
        {
            //Arrange
            var droneDirection = DroneDirection.South;
            
            //Act
            drone.EnterArena(this.arena.Object, validCoordinate, validCoordinate, droneDirection);

            //Assert
            Assert.AreEqual(droneDirection, drone.Direction);
        }
    }
}
