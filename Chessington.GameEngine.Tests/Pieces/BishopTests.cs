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
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(7, 2), bishop);

            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(2, 7));
        }
        


    }
    
    //No restriction in movement length, must move diagonally
    //Cannot jump over any other piece (friendly or enemy)
    //Captures by occupying place on which an enemy sits
    //Can't move off edge of board...
    //Test opposite of everything too
    
}