using Bowling;
using Xunit;

namespace GameTests
{
    public class GameTests
    {
        [Fact]
        public void GameShouldAllowRoll()
        {
            var game = new Game();
            game.Roll(0);
        }

        [Fact]
        public void GameShouldAllowScore()
        {
            var game = new Game();
            var result = game.Score();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(8, 8)]
        public void GameShouldPartialScoreOnSingleTurn(int expectedScore, int roll)
        {
            var game = new Game();
            game.Roll(roll);
            Assert.Equal(expectedScore, game.PartialScore());
        }

        [Theory]
        [InlineData(2, new int[] { 1, 1 })]
        [InlineData(9, new int[] { 8, 1 })]
        public void GameShouldScoreOnMultipleTurnsWithoutSpecialCases(int expectedScore, int[] rolls)
        {
            var game = new Game();
            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }
            Assert.Equal(expectedScore, game.Score());
        }

        [Theory]
        [InlineData(23, new int[] { 9, 1, 5, 3 })]
        [InlineData(37, new int[] { 8, 1, 5, 5, 9, 0 })]
        public void GameShouldScoreOnMultipleTurnsWithSpares(int expectedScore, int[] rolls)
        {
            var game = new Game();
            foreach (var roll in rolls)
            {
                game.Roll(roll);
            }
            Assert.Equal(expectedScore, game.Score());
        }

    }
}