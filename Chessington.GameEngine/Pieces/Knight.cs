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
                if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
                {
                    var move = new Square(x, y);
                    if(SquareIsEmpty(board, move) || SquareContainsEnemyPiece(board, move))
                        knightMoves.Add(move);
                }
            }
            
            return knightMoves;
        }
    }
}