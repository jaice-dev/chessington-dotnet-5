using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        [Test]

        public void WhiteBishop_CanMoveDiagonally()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(0, 2), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(2, 0));
            moves.Should().Contain(Square.At(5, 6));
        }
        
        [Test]
        
        public void BlackBishop_CanMoveDiagonally()
        {
            //TODO Split into two tests - one for moving one square, one for moving many?
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(7, 2), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(2, 7));
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
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(7, 5), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().NotContain(Square.At(7, 6));
            moves.Should().NotContain(Square.At(6, 7));
        }



    }
    //Cannot jump over any other piece (friendly or enemy)
    //Captures by occupying place on which an enemy sits
    //Test opposite of everything too
    
}