using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }
        
        public bool ThereIsAPieceBetweenCardinally(Board board, Square move)
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

            // iterate across rows to move location starting at current location. If any squares are filled, return true.
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
        
        public bool ThereIsAPieceBetweenDiagonally(Board board, Square move)
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
            var queenMoves = new List<Square>();
            
            // Add cardinal direction moves
            //iterate across current piece row
            for (var row = 0; row <= 7; row++)
            {
                if (row == currentSquare.Row)
                    continue; // Don't add current piece location to move list
                
                var move = new Square(row, currentSquare.Col);
                
                if (ThereIsAPieceBetweenCardinally(board,move))
                    continue;
                if (SquareIsEmpty(board, move) || SquareContainsEnemyPiece(board, move))
                    queenMoves.Add(move);
            }
            
            //iterate across current piece column
            for (var col = 0; col <= 7; col++)
            {
                if (col == currentSquare.Col)
                    continue; // Don't add current piece location to move list
                
                var move = new Square(currentSquare.Row, col);
                
                if (ThereIsAPieceBetweenCardinally(board,move))
                    continue;
                if (SquareIsEmpty(board, move) || SquareContainsEnemyPiece(board, move))
                    queenMoves.Add(move);
            }
            
            //Add diagonal moves
            // If Moving same number of rows horizontally and vertically, add to move list
            for (var row = 0; row <= 7; row++)
            for (var col = 0; col <= 7; col++)
                if (Math.Abs(currentSquare.Row - row) == Math.Abs(currentSquare.Col - col))
                {
                    var move = new Square(row, col);

                    //Only add move to moves if there aren't any pieces between it and current location
                    if (SquareContainsEnemyPiece(board, move) && !ThereIsAPieceBetweenDiagonally(board, move))
                        queenMoves.Add(move);
                    else if (SquareIsEmpty(board, move) && !ThereIsAPieceBetweenDiagonally(board, move)) 
                        queenMoves.Add(move);
                }
            
            return queenMoves;
            
            //Can Move along cardinal directions
            //Can Move along diagonals
            //Basically Rook and Bishop combined
            //Can't jump pieces
            //Can capture by occupying enemy space
        }
    }
}