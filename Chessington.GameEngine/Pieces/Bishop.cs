using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public bool ThereIsAPieceBetween(Board board, Square move)
        {
            var currentSquare = board.FindPiece(this);
            var diff = Math.Abs(currentSquare.Col - move.Col);

            int xdir;
            int ydir;

            //Sets direction to iterate across
            if (move.Row - currentSquare.Row > 0) xdir = 1;
            else xdir = -1;
            if (move.Col - currentSquare.Col > 0) ydir = 1;
            else ydir = -1;

            //Iterate up to move location. If any squares are filled, return true.
            for (var i = 1; i < diff; i++)
                if (!SquareIsEmpty(board, new Square(currentSquare.Row + i * xdir, currentSquare.Col + i * ydir)))
                    return true;

            return false;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //Initialise variables
            var currentSquare = board.FindPiece(this);
            var bishopMoves = new List<Square>();
            

            // If Moving same number of rows horizontally and vertically, add to move list
            for (var row = 0; row <= 7; row++)
            for (var col = 0; col <= 7; col++)
                if (Math.Abs(currentSquare.Row - row) == Math.Abs(currentSquare.Col - col))
                {
                    var move = new Square(row, col);

                    //Only add move to moves if there aren't any pieces between it and current location
                    if (SquareContainsEnemyPiece(board, move) && !ThereIsAPieceBetween(board, move))
                        bishopMoves.Add(move);
                    else if (SquareIsEmpty(board, move) && !ThereIsAPieceBetween(board, move)) 
                        bishopMoves.Add(move);
                }

            return bishopMoves;
        }
    }
}