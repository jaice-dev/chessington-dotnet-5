using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;
using FakeItEasy;

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
        
        [Test]
        public void WhiteScoreTest()
        {
            var capturedPieces = new List<Piece>()
            {
                new Pawn(Player.Black),
                new Pawn(Player.White),
                new Queen(Player.Black)
            };
            
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(capturedPieces);

            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetWhiteScore().Should().Be(10);
        }
        
        [Test]
        public void BlackScoreTest()
        {
            var capturedPieces = new List<Piece>()
            {
                new Rook(Player.White),
                new Bishop(Player.White),
                new Pawn(Player.Black)
            };


            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(capturedPieces);

            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetBlackScore().Should().Be(8);
        }
    }
}