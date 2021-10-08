using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            
            //Sets which direction pieces move (positive for forward, neg for backwards)
            int direction;
            if (Player == Player.Black)
                direction = 1;
            else
                direction = -1;
            
            moves.Add(new Square(currentSquare.Row + (1 * direction), currentSquare.Col));

            if (this.MovesTaken == 0) // If first move, can move two squares
            {
                moves.Add(new Square(currentSquare.Row + (2 * direction), currentSquare.Col));

            }

            return moves;
        }
    }
}