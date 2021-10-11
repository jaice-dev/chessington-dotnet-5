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
            var moves = GetListOfDiagonalMoves(currentSquare, direction);
            foreach (var move in moves)
            {
                TakeEnemyPiece(board, move, pawnMoves);
            }
            
            // En Passant
            // Special pawn capture
            // Only occurs immediately after a pawn makes a move of two squares on first move, and it could
            // have been captured by an enemy had it only advanced one square
            // Opponent captures the just moved pawn "as it passes" through the first square.
            // The result is the same as if the pawn had advanced only one square and the enemy pawn had captured it normally.
            
            /*
             * There are a few requirements for the move to be legal:
                The capturing pawn must have advanced exactly three ranks to perform this move.
                The captured pawn must have moved two squares in one move, landing right next to the capturing pawn.
                The en passant capture must be performed on the turn immediately after the pawn being captured moves. 
                If the player does not capture en passant on that turn, they no longer can do it later.
             */
            
            //En Passant
            //check neighbor squares
            var leftNeighbour = getMove(currentSquare, direction, 0, -1);
            

            return pawnMoves;
        }

        private IEnumerable<Square> GetListOfDiagonalMoves(Square currentSquare, int direction)
        {
            List<Square> listOfMoves = new List<Square>();
            if (currentSquare.Col == 0) // If at left horizontal edge of board
            {
                listOfMoves.Add(getMove(currentSquare, direction, 1, 1));
            }
            else if (currentSquare.Col == 7) // If at right horiznatal edge of board
            {
                listOfMoves.Add(getMove(currentSquare, direction, 1, -1));
            }
            else // Move in both directions
            {
                listOfMoves.Add(getMove(currentSquare, direction, 1, 1));
                listOfMoves.Add(getMove(currentSquare, direction, 1, -1));
            }

            return listOfMoves;
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