using NUnit.Framework;
using Drones.Enums;

namespace Drones.Tests.DroneTests
{
    [TestFixture]
    public class MoveTests : DroneTestsBase
    {
        [Test]
        public void Move_DroneNotInArena_NoMovement()
        {
            //Arrange
            
            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(0, this.drone.Longitude);
            Assert.AreEqual(0, this.drone.Latitude);
        }

        [Test]
        public void Move_DroneFacingNorth_DroneLongitudeIncreasesByOne()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, 0, 0, DroneDirection.North);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(1, this.drone.Longitude);
        }

        [Test]
        public void Move_DroneFacingEast_DroneLatitiudeIncreasesByOne()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, 0, 0, DroneDirection.East);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(1, this.drone.Latitude);
        }

        [Test]
        public void Move_DroneFacingSouth_LongitudeDecreasesByOne()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, DroneDirection.South);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(upperCoordinate - 1, this.drone.Longitude);
        }

        [Test]
        public void Move_DroneFacingWest_DroneLatitiudeDecreasesByOne()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, DroneDirection.West);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(upperCoordinate - 1, this.drone.Latitude);
        }

        [Test]
        public void Move_DroneOnLeftEdgeOfArenaFacingWest_DroneDoesNotMove()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, 0, 0, DroneDirection.West);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(0, this.drone.Latitude);
        }

        [Test]
        public void Move_DroneOnBottomEdgeOfArenaFacingSouth_DroneDoesNotMove()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, 0, 0, DroneDirection.South);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(0, this.drone.Longitude);
        }

        [Test]
        public void Move_DroneOnTopEdgeOfArenaFacingNorth_DroneDoesNotMove()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, DroneDirection.North);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(upperCoordinate, this.drone.Longitude);
        }

        [Test]
        public void Move_DroneOnRightEdgeOfArenaFacingEast_DroneDoesNotMove()
        {
            //Arrange
            this.drone.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, DroneDirection.East);

            //Act
            this.drone.Move();

            //Assert
            Assert.AreEqual(upperCoordinate, this.drone.Latitude);
        }
    }
}
