using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void TestAllGutterballs()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(17,0);
            
            Assert.AreEqual(16,game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(1);
            game.Roll(3);

            Assert.AreEqual(18, game.Score());
        }


        [TestMethod]
        public void TestFullGame()
        {
            int[] fullRolls = new int[]{8,0,7,0,5,3,9,1,9,1,10,8,0,5,1,3,7,9,0,0};
            RollValues(fullRolls);

            Assert.AreEqual(122, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

        private void RollMany(int numberOfRolls, int pins)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game.Roll(pins);
        }
        private void RollValues(int[] rolls)
        {
            for (int i = 0; i < rolls.Length; i++)
                game.Roll(rolls[i]);
        }
    }
}
