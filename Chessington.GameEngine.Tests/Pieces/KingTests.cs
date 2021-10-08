using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        //collision with ally and enemy pieces

        [Test]
        public void King_CanMoveCardinalDirections()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(3, 3), king);

            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(4, 3));
            moves.Should().Contain(Square.At(2, 3));
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(3, 2));
        }

        [Test]
        public void King_CanMoveHorizontally()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(3, 3), king);

            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(4, 4));
            moves.Should().Contain(Square.At(2, 2));
            moves.Should().Contain(Square.At(2, 4));
            moves.Should().Contain(Square.At(4, 2));
        }

        [Test]
        public void King_CantMoveMoreThanOneSquare()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(3, 3), king);

            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(5, 3));
            moves.Should().NotContain(Square.At(5, 5));
        }

        [Test]
        public void King_CantMoveIfBlockedByPiece()
        {
            var board = new Board();
            var king = new King(Player.White);
            var blocker1 = new Rook(Player.White);
            var blocker2 = new Rook(Player.White);

            board.AddPiece(Square.At(3, 3), king);
            board.AddPiece(Square.At(3, 4), blocker1);
            board.AddPiece(Square.At(4, 4), blocker2);

            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(3, 4));
            moves.Should().NotContain(Square.At(4, 4));
        }

        [Test]
        public void King_CanTakeEnemyPiece()
        {
            var board = new Board();
            var king = new King(Player.White);
            var enemy = new Rook(Player.Black);

            board.AddPiece(Square.At(3, 3), king);
            board.AddPiece(Square.At(3, 4), enemy);

            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(3, 4));
        }

        [Test]
        public void King_CantMoveToSelf()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(3, 3), king);
            
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(3, 3));
        }
    }
}