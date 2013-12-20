using Moq;
using NUnit.Framework;
using Drones.Builders;
using Drones.CommandReaders;
using Drones.Enums;

namespace Drones.Tests.CommandReadersTests.CreateDroneCommandReaderTests
{
    [TestFixture]
    public class ProcessTests
    {
        const uint latitude = 1;
        const uint longitude = 2;
        const uint largeLatitude = 10;
        const uint largeLongitude = 20;
        
        private Mock<IContext> context;
        private Mock<IArena> arena;
        private Mock<IDroneBuilder> droneBuilder;
        private CreateDroneCommandReader _createDroneCommandReader;
        private Mock<IDrone> drone;


        [SetUp]
        public void Setup()
        {
            this.context = new Mock<IContext>();
            this.arena = new Mock<IArena>();

            this.context.SetupGet(c => c.Arena).Returns(this.arena.Object);
            this.context.SetupProperty(c => c.LatestDrone);

            this.droneBuilder = new Mock<IDroneBuilder>();
            this.context.SetupGet(c => c.DroneBuilder).Returns(this.droneBuilder.Object);

            this.drone = new Mock<IDrone>();
            this.droneBuilder.Setup(rb => rb.Create())
                             .Returns(this.drone.Object);


            this._createDroneCommandReader = new CreateDroneCommandReader(this.context.Object, null);
        }

        private string BuildCommand(uint lat, uint lng, DroneDirection direction)
        {
            string stringDirection;
            switch (direction)
            {
                case DroneDirection.North:
                    stringDirection = "N";
                    break;
                case DroneDirection.South:
                    stringDirection = "S";
                    break;
                case DroneDirection.East:
                    stringDirection = "E";
                    break;
                default:
                    stringDirection = "W";
                    break;
            }

            return string.Format("{0} {1} {2}", lat, lng, stringDirection);
        }

        [Test]
        public void ProcessCreateDroneCommand_TwoDigitsAndADirectionSupplied_CreateDrone()
        {
            //Arrange
            string command = this.BuildCommand(1, 2, DroneDirection.North);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.droneBuilder.Verify(rb => rb.Create(), Times.Once());
        }

        [Test]
        public void ProcessCreateDroneCommand_ValidCommandSent_DroneEntersArena()
        {
            //Arrange
            const DroneDirection droneDirection = DroneDirection.North;
            string command = this.BuildCommand(latitude, longitude, droneDirection);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(this.arena.Object, It.IsAny<uint>(), It.IsAny<uint>(), It.IsAny<DroneDirection>()), Times.Once());
        }

        [Test]
        public void ProcessCreateDroneCommand_TwoDigitsAndADirectionSupplied_EnterArenaWithCorrectLatitude()
        {
            //Arrange
            string command = this.BuildCommand(latitude, 2, DroneDirection.North);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), latitude, It.IsAny<uint>(), It.IsAny<DroneDirection>()));
        }

        [Test]
        public void ProcessCreateDroneCommand_TwoLargeDigitsAndADirectionSupplied_EnterArenaWithCorrectLatitude()
        {
            //Arrange
            string command = this.BuildCommand(largeLatitude, largeLongitude, DroneDirection.North);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), largeLatitude, It.IsAny<uint>(), It.IsAny<DroneDirection>()));
        }

        [Test]
        public void ProcessCreateDroneCommand_TwoLargeDigitsAndADirectionSupplied_EnterArenaWithCorrectLongitude()
        {
            //Arrange
            string command = this.BuildCommand(largeLatitude, largeLongitude, DroneDirection.North);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), largeLongitude, It.IsAny<DroneDirection>()));
        }

        [Test]
        public void ProcessCreateDroneCommand_ALetterADigitsAndADirectionSupplied_DoNotCreateDrone()
        {
            //Arrange
            string command = "A 20 N";

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.droneBuilder.Verify(rb => rb.Create(), Times.Never());
        }

        [Test]
        public void ProcessCreateDroneCommand_ValidCommandSent_EnterArenaWithCorrectLongitude()
        {
            //Arrange
            string command = this.BuildCommand(latitude, longitude, DroneDirection.North);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), longitude, It.IsAny<DroneDirection>()));
        }

        [Test]
        public void ProcessCreateDroneCommand_ValidCommandSentForSouth_EnterArenaWithCorrectDirection()
        {
            //Arrange
            const DroneDirection droneDirection = DroneDirection.South;
            string command = this.BuildCommand(latitude, longitude, droneDirection);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), It.IsAny<uint>(), droneDirection));
        }

        [Test]
        public void ProcessCreateDroneCommand_ValidCommandSentForEast_EnterArenaWithCorrectDirection()
        {
            //Arrange
            const DroneDirection droneDirection = DroneDirection.East;
            string command = this.BuildCommand(latitude, longitude, droneDirection);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), It.IsAny<uint>(), droneDirection));
        }

        [Test]
        public void ProcessCreateDroneCommand_ValidCommandSentForWest_EnterArenaWithCorrectDirection()
        {
            //Arrange
            const DroneDirection droneDirection = DroneDirection.West;
            string command = this.BuildCommand(latitude, longitude, droneDirection);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.drone.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), It.IsAny<uint>(), droneDirection));
        }

        [Test]
        public void ProcessCreateDroneCommand_InvalidDirectionSent_DroneNotCreated()
        {
            //Arrange
            string command = "10 20 F";

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            this.droneBuilder.Verify(rb => rb.Create(), Times.Never());
        }

        [Test]
        public void ProcessCreateDroneCommand_ValidCommandSent_DroneSaved()
        {
            //Arrange
            const DroneDirection droneDirection = DroneDirection.North;
            string command = this.BuildCommand(latitude, longitude, droneDirection);

            //Act
            this._createDroneCommandReader.Process(command);

            //Assert
            Assert.AreSame(this.drone.Object, this.context.Object.LatestDrone);
        }

    }
}
