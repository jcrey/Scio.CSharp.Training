using Moq;
using NUnit.Framework;
using Drones.Commands;

namespace Drones.Tests.CommandTests
{
    [TestFixture]
    public class MoveCommandTests
    {
        private Mock<IDrone> drone;
        private MoveCommand command;

        [SetUp]
        public void Setup()
        {
            this.drone = new Mock<IDrone>();
            this.command = new MoveCommand();
        }

        [Test]
        public void Execute_DroneIsNull_ReturnFalse()
        {
            //Arrange
            
            //Act
            bool result = this.command.Execute('M', null);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_DroneSupplied_ReturnTrue()
        {
            //Arrange
            
            //Act
            bool result = this.command.Execute('M', this.drone.Object);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_DroneSupplied_MoveCalledOnDrone()
        {
            //Arrange

            //Act
            this.command.Execute('M', this.drone.Object);

            //Assert
            this.drone.Verify(r => r.Move(), Times.Once());
        }

        [Test]
        public void Execute_CommandNotSupplied_ReturnFalse()
        {
            //Arrange
            
            //Act
            var result = this.command.Execute(' ', this.drone.Object);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_PassValidCharacter_ReturnTrue()
        {
            //Arrange
            
            //Act
            var result = this.command.IsValid('M');

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_PassValidLowecaseCharacter_ReturnTrue()
        {
            //Arrange
            
            //Act
            var result = this.command.IsValid('m');

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_PassInvalidCharacter_ReturnFalse()
        {
            //Arrange
            
            //Act
            var result = this.command.IsValid('X');

            //Assert
            Assert.IsFalse(result);
        }
    }
}
