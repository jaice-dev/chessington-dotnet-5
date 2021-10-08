using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public bool ThereIsAPieceBetween(Board board, Square move)
        {
            //Start at current location, iterate up to movelocation
            //If any spaces are filled, return True
            //Else, return False
            var currentSquare = board.FindPiece(this);
            var rowDiff = Math.Abs(currentSquare.Row - move.Row);
            var colDiff = Math.Abs(currentSquare.Col - move.Col);
            
            int xdir;
            int ydir;

            //Sets direction to iterate across
            if (move.Row - currentSquare.Row > 0) xdir = 1;
            else xdir = -1;
            if (move.Col - currentSquare.Col > 0) ydir = 1;
            else ydir = -1;
            
            // iterate across cols to move location starting at current location. If any squares are filled, return true.
            if (rowDiff == 0)
            {
                for (var i = 1; i < colDiff; i++)
                {
                    if (!SquareIsEmpty(board, new Square(currentSquare.Row, currentSquare.Col + i * ydir)))
                        return true;
                }
            }

            // iterate across cols to move location starting at current location. If any squares are filled, return true.
            if (colDiff == 0)
            {
                for (var i = 1; i < rowDiff; i++)
                {
                    if (!SquareIsEmpty(board, new Square(currentSquare.Row + i * xdir, currentSquare.Col)))
                        return true;
                }
            }
            
            return false;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var rookMoves = new List<Square>();

            for (var row = 0; row <= 7; row++)
            {
                if (row == currentSquare.Row)
                    continue;
                var move = new Square(row, currentSquare.Col);
                
                if (ThereIsAPieceBetween(board,move))
                    continue;
                if (SquareIsEmpty(board, move) || SquareContainsEnemyPiece(board, move))
                    rookMoves.Add(move);
            }

            for (var col = 0; col <= 7; col++)
            {
                if (col == currentSquare.Col)
                    continue;
                var move = new Square(currentSquare.Row, col);
                if (ThereIsAPieceBetween(board,move))
                    continue;
                if (SquareIsEmpty(board, move) || SquareContainsEnemyPiece(board, move))
                    rookMoves.Add(move);
            }

            return rookMoves;

            // Can Move forwards and backwards
            // Can't move diagonally
            // Can't jump pieces
            // Captures by moving into
        }
    }
}