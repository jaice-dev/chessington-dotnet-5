using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public bool SquareIsEmpty(Board board, Square square)
        {
            if (board.GetPiece(square) != null) 
                return false;
            return true;
        }

        public bool SquareContainsEnemyPiece(Board board, Square square)
        {
            if (board.GetPiece(square) != null)
                if (board.GetPiece(square).Player != Player)
                    return true;
            return false;
        }

        public int MovesTaken = 0;
        
        public Player Player { get; private set; }
        
        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            MovesTaken++;
        }
    }
}