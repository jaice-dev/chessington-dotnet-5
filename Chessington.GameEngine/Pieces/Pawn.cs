using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public bool SquareIsEmpty(Board board, Square square)
        {
            if (board.GetPiece(square) != null)
            {
                return false;
            }
            return true;
        }

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

            // If first move, can move two squares
            if (this.MovesTaken == 0)
            {
                moves.Add(new Square(currentSquare.Row + (2 * direction), currentSquare.Col));

            }
            
            // Check if moves list contains pre-existing pieces. If so, remove them.
            foreach (var move in moves.ToList())
            {
                if (this.MovesTaken == 0)
                {
                    //If first move, and move is two ahead
                    //If first square is blocked
                    //Remove move
                }
                if (!SquareIsEmpty(board, move))
                {
                    moves.Remove(move);
                }
            }

            return moves;
        }
    }
}