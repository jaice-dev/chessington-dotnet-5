using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        [Test]
        public void Rook_CanMoveInCardinalDirections()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), rook);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 5));
            moves.Should().Contain(Square.At(4, 3));
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(5, 4));
        }
        
        [Test]
        public void Rook_CanMoveMultipleSquares()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), rook);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 7));
            moves.Should().Contain(Square.At(4, 1));
            moves.Should().Contain(Square.At(2, 4));
            moves.Should().Contain(Square.At(6, 4));
        }
        
        [Test]
        public void Rook_CantMoveDiagonally()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), rook);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(3, 3));
            moves.Should().NotContain(Square.At(5, 3));
            moves.Should().NotContain(Square.At(3, 5));
        }

        [Test]
        public void Rook_CantMoveToSelf()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), rook);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(4, 4));
        }
        
        [Test]
        public void Rook_CantMovePastBlockers()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            var blocker = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), rook);
            board.AddPiece(Square.At(4,5), blocker);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(4, 5));
            moves.Should().NotContain(Square.At(4, 6));
        }
        
        [Test]
        public void Rook_CanMoveToEnemySpace()
        {
            //But not beyond
            var board = new Board();
            var rook = new Rook(Player.White);
            var blocker = new Rook(Player.Black);
            board.AddPiece(Square.At(4, 4), rook);
            board.AddPiece(Square.At(4,5), blocker);

            var moves = rook.GetAvailableMoves(board);
    
            moves.Should().Contain(Square.At(4, 5));
            moves.Should().NotContain(Square.At(4, 6));
        }
    }
}