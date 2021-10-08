using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void Knight_CanMoveLShape()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(0, 1), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 2));
            moves.Should().Contain(Square.At(2, 0));
        }
        
        [Test]
        public void Knight_CanJumpOverPiece()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            var blocker = new Rook(Player.White);
            var blocker2 = new Rook(Player.White);
            var blocker3 = new Rook(Player.White);

            board.AddPiece(Square.At(0, 1), knight);
            board.AddPiece(Square.At(1, 0), blocker);
            board.AddPiece(Square.At(1, 1), blocker2);
            board.AddPiece(Square.At(1, 2), blocker3);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 2));
            moves.Should().Contain(Square.At(2, 0));
        }
        
        [Test]
        public void Knight_CanCaptureEnemyPiece()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            var enemy = new Rook(Player.Black);

            board.AddPiece(Square.At(3, 3), knight);
            board.AddPiece(Square.At(4, 5), enemy);


            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 5));
        }
        
        [Test]
        public void Knight_CantMoveToSelf()
        {
            var board = new Board();
            var knight = new Knight(Player.White);

            board.AddPiece(Square.At(0, 1), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(0, 1));

        }
    }
}