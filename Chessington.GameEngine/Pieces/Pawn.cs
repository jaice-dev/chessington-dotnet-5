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

        public bool SquareContainsEnemyPiece(Board board, Square square)
        {
            if (board.GetPiece(square) != null)
            {
                if (board.GetPiece(square).Player != this.Player)
                {
                    return true;
                }
            }
            return false;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //Initialise variables
            var currentSquare = board.FindPiece(this);
            var pawnMoves = new List<Square>();

            //Sets which direction pieces move (positive for forward, neg for backwards)
            int direction;
            if (Player == Player.Black)
                direction = 1;
            else
                direction = -1;
            
            //Initialise possible moves
            Square moveOneSquareForwards = new Square(currentSquare.Row + (1 * direction), currentSquare.Col);
            Square moveTwoSquaresForwards = new Square(currentSquare.Row + (2 * direction), currentSquare.Col);


            //Diagonal Moves
            if (currentSquare.Col == 0) // If at left horizontal edge of board
            {
                Square moveDiagonal = new Square(currentSquare.Row + (1 * direction), currentSquare.Col + 1);
                if (SquareContainsEnemyPiece(board, moveDiagonal)) pawnMoves.Add(moveDiagonal);
            }
            else if (currentSquare.Col == 7) // If at right horiznatal edge of board
            {
                Square moveDiagonal = new Square(currentSquare.Row + (1 * direction), currentSquare.Col - 1);
                if (SquareContainsEnemyPiece(board, moveDiagonal)) pawnMoves.Add(moveDiagonal);
            }
            else // Move in both directions
            {
                Square moveFirstDiagonal = new Square(currentSquare.Row + (1 * direction), currentSquare.Col + (1 * direction));
                Square moveSecondDiagonal = new Square(currentSquare.Row + (1 * direction), currentSquare.Col - (1 * direction));
                if (SquareContainsEnemyPiece(board, moveFirstDiagonal)) pawnMoves.Add(moveFirstDiagonal);
                if (SquareContainsEnemyPiece(board, moveSecondDiagonal)) pawnMoves.Add(moveSecondDiagonal);

            }

            // If square ahead is empty, add to move list
            if (SquareIsEmpty(board, moveOneSquareForwards)) pawnMoves.Add(moveOneSquareForwards);

            // If first move, can move two squares if both squares ahead are empty
            if (MovesTaken == 0 && SquareIsEmpty(board, moveOneSquareForwards) &&
                SquareIsEmpty(board, moveTwoSquaresForwards)) pawnMoves.Add(moveTwoSquaresForwards);

            return pawnMoves;
        }
    }
}