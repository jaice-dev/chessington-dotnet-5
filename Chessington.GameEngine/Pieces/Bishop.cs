using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //Initialise variables
            var currentSquare = board.FindPiece(this);
            var bishopMoves = new List<Square>();

            // If Moving same number of rows horizontally and vertically, add to move list
            for(var row = 0; row <= 7; row++)
            {
                for (var col = 0; col <= 7; col++)
                {
                    if (Math.Abs(currentSquare.Row - row) == Math.Abs(currentSquare.Col - col))
                    {
                        bishopMoves.Add(new Square(row, col));
                    }
                }
            }

            return bishopMoves;
        }
    }
}