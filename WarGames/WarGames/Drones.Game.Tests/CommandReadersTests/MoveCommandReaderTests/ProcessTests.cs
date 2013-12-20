using Moq;
using NUnit.Framework;
using Drones.CommandReaders;

namespace Drones.Tests.CommandReadersTests.MoveCommandReaderTests
{
    [TestFixture]
    public class ProcessTests
    {
        private Mock<IContext> context;
        private Mock<IDrone> drone;
        private MoveDroneCommandReader moveCommandReader; 

        [SetUp]
        public void Setup()
        {
            this.context = new Mock<IContext>();
            this.drone = new Mock<IDrone>();

            this.context.SetupGet(c => c.LatestDrone).Returns(this.drone.Object);

            this.moveCommandReader = new MoveDroneCommandReader(this.context.Object,null, null);
        }

        [Test]
        public void ProcessMoveDroneCommand_DroneAskedToMoveOnce_DroneMovesOnce()
        {
            //Arrange

            //Act
            this.moveCommandReader.Process("M");

            //Assert
            this.drone.Verify(r => r.Move(), Times.Once());
        }

        [Test]
        public void ProcessMoveDroneCommand_DroneAskedToMoveFiveTimes_DroneMovesFiveTimes()
        {
            //Arrange
            string command = "MMMMM";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Move(), Times.Exactly(5));
        }

        [Test]
        public void ProcessMoveDroneCommand_InvalidCommand_DroneDoesNotMove()
        {
            //Arrange
            string command = "G";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Move(), Times.Never());
        }

        [Test]
        public void ProcessMoveDroneCommand_RotateDroneCommand_DroneRotatesClockwiseOnce()
        {
            //Arrange
            string command = "R";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Rotate(true), Times.Once());
        }

        [Test]
        public void ProcessMoveDroneCommand_RotateDroneFourTimes_DroneRotatesClockwiseFourTimes()
        {
            //Arrange
            string command = "RRRR";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Rotate(true), Times.Exactly(4));
        }

        [Test]
        public void ProcessMoveDroneCommand_RotateDroneAnticlockwiseCommand_DroneRotatesAnticlockwiseOnce()
        {
            //Arrange
            string command = "L";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Rotate(false), Times.Once());
        }

        [Test]
        public void ProcessMoveDroneCommand_RotateDroneAnticlockwiseFourTimes_DroneRotatesAnticlockwiseFourTimes()
        {
            //Arrange
            string command = "LLLL";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Rotate(false), Times.Exactly(4));
        }

        [Test]
        public void ProcessMoveDroneCommand_MoveDroneThreeTimesRotateRightOnceMoveTwice_DroneMovesThreeTimesThenRotatesClockwiseThenMovesTwice()
        {
            //Arrange
            string command = "MMMRMM";

            //Act
            this.moveCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.Move(), Times.Exactly(5));
            this.drone.Verify(r => r.Rotate(true), Times.Once());
        }
    }
}
