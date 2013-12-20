using Moq;
using NUnit.Framework;
using Drones.Commands;

namespace Drones.Tests.CommandTests
{
    [TestFixture]
    public class RotateCommandTests : CommandTestsBase
    {
        private RotateCommand command;

        public override void Setup()
        {
            base.Setup();
            this.command = new RotateCommand();
        }

        [Test]
        public void Execute_EmptyArgumentSent_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = this.command.Execute(' ', this.drone.Object);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_RotateLeftArgumentSent_DroneToldToRotateAnticlockwise()
        {
            //Arrange

            //Act
            this.command.Execute('L', this.drone.Object);

            //Assert
            this.drone.Verify(r => r.Rotate(false), Times.Once());
        }

        [Test]
        public void Execute_RotateRightArgumentSent_DroneToldToRotateClockwise()
        {
            //Arrange

            //Act
            this.command.Execute('R', this.drone.Object);

            //Assert
            this.drone.Verify(r => r.Rotate(true), Times.Once());
        }

        [Test]
        public void Execute_UnrecognisedArgumentSent_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = this.command.Execute('X', this.drone.Object);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_LowercaseRecognisedLeftArgumentSent_RotateDroneAnticlockwise()
        {
            //Arrange

            //Act
            this.command.Execute('l', this.drone.Object);

            //Assert
            this.drone.Verify(r => r.Rotate(false), Times.Once());
        }

        [Test]
        public void Execute_LowercaseRecognisedRightArgumentSent_RotateDroneClockwise()
        {
            //Arrange

            //Act
            this.command.Execute('r', this.drone.Object);

            //Assert
            this.drone.Verify(r => r.Rotate(true), Times.Once());
        }
    }
}