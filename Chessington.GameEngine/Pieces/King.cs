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
            
            //Initialise area to iterate over
            //If out of bound, set to edge of bounds
            var rowStart = currentSquare.Row - 1;
            if (rowStart < 0) rowStart = 0;

            var rowEnd = currentSquare.Row + 1;
            if (rowEnd > 7) rowEnd = 7;

            var colStart = currentSquare.Col - 1;
            if (colStart < 0) colStart = 0;

            var colEnd = currentSquare.Col + 1;
            if (colEnd > 7) colEnd = 7;

            for (var row = rowStart; row <= rowEnd; row++)
            for (var col = colStart; col <= colEnd; col++)
            {
                if (col == currentSquare.Col && row == currentSquare.Row) continue;
                var move = new Square(row, col);
                if(SquareIsEmpty(board, move) || SquareContainsEnemyPiece(board, move))
                {
                    kingMoves.Add(move);
                }
            }


            return kingMoves;
            
            //TODO implement Check and Checkmate / Castling
        }
    }
}