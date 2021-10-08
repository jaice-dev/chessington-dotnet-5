using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //Initialise variables
            var currentSquare = board.FindPiece(this);
            var queenMoves = new List<Square>();
            
            
            
            return queenMoves;
            
            //Can Move along cardinal directions
            //Can Move along diagonals
            //Basically Rook and Bishop combined
            //Can't jump pieces
            //Can capture by occupying enemy space
        }
    }
}