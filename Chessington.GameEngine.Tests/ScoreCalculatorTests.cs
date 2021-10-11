using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class ScoreCalculatorTests
    {
        [Test]
        public void ScoreCalculator_Returns0WhenBoardIsEmpty()
        {
            var board = new Board();
            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetBlackScore().Should().Be(0);
            scoreCalculator.GetWhiteScore().Should().Be(0);
        }
    }
}