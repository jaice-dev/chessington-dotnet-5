using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //Initialise variables
            var currentSquare = board.FindPiece(this);
            var knightMoves = new List<Square>();
            
            //Possible moves
            int []X = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int []Y = { 1, 2, 2, 1, -1, -2, -2, -1 };

            int count = 0;

            for (int i = 0; i <= 7; i++)
            {
                //new position
                int x = currentSquare.Row + X[i];
                int y = currentSquare.Col + Y[i];
                
                //if move is valid, add to move list
            }


            return knightMoves;
            // L shaped moves
            // Can jump over pieces
            // Capture by landing on piece
        }
    }
}