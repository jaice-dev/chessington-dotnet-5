using System.Collections.Generic;
using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        [Test]

        public void WhiteBishop_CanMoveDiagonallyForwards()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(0, 2), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(2, 0));
            moves.Should().Contain(Square.At(5, 7));
        }
        
        [Test]
        
        public void BlackBishop_CanMoveDiagonallyForwards()
        {
            //TODO Split into two tests - one for moving one square, one for moving many?
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            board.AddPiece(Square.At(7, 2), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(2, 7));
        }
        
        [Test]
        
        public void WhiteBishop_CanMoveDiagonallyBackwards()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 4), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(2, 2));
            moves.Should().Contain(Square.At(1, 7));
        }
        
        [Test]
        
        public void BlackBishop_CanMoveDiagonallyBackwards()
        {
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            board.AddPiece(Square.At(4, 5), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(6, 3));
            moves.Should().Contain(Square.At(6, 7));
        }

        
        [Test]
        public void WhiteBishop_CannotMoveVerticallyOrHorizontally()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(0, 2), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(1, 2));
            moves.Should().NotContain(Square.At(0, 3));
        }
        
        [Test]
        public void BlackBishop_CannotMoveVerticallyOrHorizontally()
        {
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            board.AddPiece(Square.At(7, 5), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(7, 6));
            moves.Should().NotContain(Square.At(6, 7));
        }
        
        [Test]
        public void Bishop_CannotJumpFriendlyPiece()
        {
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            var blockingPiece = new Rook(Player.Black);
            board.AddPiece(Square.At(3, 3), bishop);
            board.AddPiece(Square.At(5,5), blockingPiece);

            var moves = bishop.GetAvailableMoves(board).ToList();
            moves.Should().NotContain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(6, 6));
            moves.Should().NotContain(Square.At(7, 7));
        }
        
        [Test]
        public void BlackBishop_CanTakeEnemyPiece()
        {
            //But not move past it
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(3, 3), bishop);
            board.AddPiece(Square.At(5,5), rook);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(6, 6));
            moves.Should().NotContain(Square.At(7, 7));
        }
        
        

    }

}