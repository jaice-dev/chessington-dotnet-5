using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class QueenTests
    {
        [Test]
        public void Queen_CanMoveInCardinalDirections()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 5));
            moves.Should().Contain(Square.At(4, 3));
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(5, 4));
        }
        
        [Test]
        public void Queen_CanMoveMultipleSquaresCardinally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 7));
            moves.Should().Contain(Square.At(4, 1));
            moves.Should().Contain(Square.At(2, 4));
            moves.Should().Contain(Square.At(6, 4));
        }

        [Test]
        public void Queen_CanMoveDiagonally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(3, 5));
            moves.Should().Contain(Square.At(5, 3));
        }
        
        [Test]
        public void Queen_CanMoveDiagonallyMultipleSpaces()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 6));
            moves.Should().Contain(Square.At(0, 0));
            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(1, 7));
        }
        
        [Test]
        public void Queen_CantMoveToSelf()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(4, 4));

        }
        
        [Test]
        public void Queen_CantMovePastBlockers()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            var blocker = new Rook(Player.White);
            var blocker2 = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), queen);
            board.AddPiece(Square.At(4,5), blocker);
            board.AddPiece(Square.At(5,5), blocker2);


            var moves = queen.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(4, 5));
            moves.Should().NotContain(Square.At(4, 6));
            moves.Should().NotContain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(6, 6));
        }
                
        [Test]
        public void Queen_CanMoveToEnemySpace()
        {
            //But not beyond
            var board = new Board();
            var queen = new Queen(Player.White);
            var blocker = new Rook(Player.Black);
            var blocker2 = new Rook(Player.Black);
            board.AddPiece(Square.At(4, 4), queen);
            board.AddPiece(Square.At(4,5), blocker);
            board.AddPiece(Square.At(5,5), blocker2);

            var moves = queen.GetAvailableMoves(board).ToList();
    
            moves.Should().Contain(Square.At(4, 5));
            moves.Should().NotContain(Square.At(4, 6));
            moves.Should().Contain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(6, 6));
        }

    }
}