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
        public void GameShouldScoreOnSingleTurn(int expectedScore, int roll)
        {
            var game = new Game();
            game.Roll(roll);
            Assert.Equal(expectedScore, game.Score());
        }

    }
}