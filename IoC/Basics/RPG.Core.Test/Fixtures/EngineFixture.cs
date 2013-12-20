using NUnit.Framework;

namespace RPG.Core.Test
{
    [TestFixture]
    public class EngineFixture
    {
        /// <summary>
        /// This test answer the question:
        /// How do we use the RPG game Engine?
        /// </summary>
        [Test]
        public void NormalUsage()
        {
            var player = new TestCharacter { Blood = 100 };
            var target = new Engine(player);

            Assert.That(target.Points, Is.EqualTo(0));

            var map = new TestSuccessAdventure();

            target.Run(map);

            Assert.That(target.Points, Is.EqualTo(10000));
            Assert.That(map.Completed, Is.True);
            Assert.That(player.Blood, Is.EqualTo(100)); // Flawless victory
        }

        /// <summary>
        /// This test answer the question:
        /// How do we know when the game ends and the character died?
        /// </summary>
        [Test]
        public void PlayerDies()
        {
            var player = new TestCharacter { Blood = 100 };
            var target = new Engine(player);

            Assert.That(target.Points, Is.EqualTo(0));

            var map = new TestFailAdventure();

            target.Run(map);

            Assert.That(target.Points, Is.EqualTo(0));
            Assert.That(map.Completed, Is.False);
            Assert.That(player.Blood, Is.EqualTo(0));
        }
    }
}
