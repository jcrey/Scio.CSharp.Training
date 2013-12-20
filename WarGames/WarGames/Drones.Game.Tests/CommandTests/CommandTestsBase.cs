using Moq;
using NUnit.Framework;

namespace Drones.Tests.CommandTests
{
    public class CommandTestsBase
    {
        protected Mock<IDrone> drone;

        [SetUp]
        public virtual void Setup()
        {
            this.drone = new Mock<IDrone>();
        }
    }
}