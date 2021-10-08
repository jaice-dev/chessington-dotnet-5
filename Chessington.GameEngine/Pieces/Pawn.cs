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
            
            Square moveOneSquare = new Square(currentSquare.Row + (1 * direction), currentSquare.Col);
            Square moveTwoSquares = new Square(currentSquare.Row + (2 * direction), currentSquare.Col);

            // If square ahead is empty, add to move list
            if (SquareIsEmpty(board, moveOneSquare))
            {
                moves.Add(moveOneSquare);
            }
            
            // If first move, can move two squares if both squares ahead are empty
            if (this.MovesTaken == 0 && SquareIsEmpty(board, moveOneSquare) && SquareIsEmpty(board, moveTwoSquares))
            {
                moves.Add(moveTwoSquares);
            }

            return moves;
        }
    }
}