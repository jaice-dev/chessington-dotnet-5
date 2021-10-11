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
            //Initialise variables
            var currentSquare = board.FindPiece(this);
            var pawnMoves = new List<Square>();

            //Sets which direction pieces move (positive for forward, neg for backwards)
            var direction = GetDirection();

            // If square ahead is empty, add to move list
            var moveOneSquareForwards = getMove(currentSquare, direction, 1);
            if (SquareIsEmpty(board, moveOneSquareForwards)) pawnMoves.Add(moveOneSquareForwards);
            
            // If first move, can move two squares if both squares ahead are empty
            var moveTwoSquaresForwards = getMove(currentSquare, direction, 2);
            if (MovesTaken == 0 && SquareIsEmpty(board, moveOneSquareForwards) &&
                SquareIsEmpty(board, moveTwoSquaresForwards)) pawnMoves.Add(moveTwoSquaresForwards);


            //Diagonal Moves
            if (currentSquare.Col == 0) // If at left horizontal edge of board
            {
                var moveRightDiagonal = getMove(currentSquare, direction, 1, 1);
                TakeEnemyPiece(board, moveRightDiagonal, pawnMoves);
            }
            else if (currentSquare.Col == 7) // If at right horiznatal edge of board
            {
                var moveLeftDiagonal = getMove(currentSquare, direction, 1, -1);
                TakeEnemyPiece(board, moveLeftDiagonal, pawnMoves);
            }
            else // Move in both directions
            {
                var moveRightDiagonal = getMove(currentSquare, direction, 1, 1);
                TakeEnemyPiece(board, moveRightDiagonal, pawnMoves);
                var moveLeftDiagonal = getMove(currentSquare, direction, 1, -1);
                TakeEnemyPiece(board, moveLeftDiagonal, pawnMoves);

            }
            
            

            return pawnMoves;
        }

        private void TakeEnemyPiece(Board board, Square move, List<Square> pawnMoves)
        {
            if (SquareContainsEnemyPiece(board, move)) pawnMoves.Add(move);
        }

        private int GetDirection()
        {
            int direction;
            if (Player == Player.Black)
                direction = 1;
            else
                direction = -1;
            return direction;
        }

        private Square getMove(Square currentSquare, int direction, int rowDiff, int colDirection=0)
        {
            return new (currentSquare.Row + (rowDiff * direction), currentSquare.Col + colDirection);
        }
    }
}