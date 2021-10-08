using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var kingMoves = new List<Square>();


            return kingMoves;
            
            // one square in any direction (not off the board)
            //captures by moving onto other square
            //TODO implement Check and Checkmate / Castling
        }
    }
}