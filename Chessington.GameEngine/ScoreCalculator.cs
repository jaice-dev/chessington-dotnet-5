using System.Collections.Generic;
using System.Windows.Input;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private IBoard _board;

        private Dictionary<string, int> scoresDict = new Dictionary<string, int>()
        {
            {"Pawn", 1},
            {"Bishop", 3},
            {"Knight", 3},
            {"Rook", 5},
            {"Queen", 9}
        };

        public ScoreCalculator(IBoard board)
        {
            _board = board;
        }

        public int GetWhiteScore()
        {
            var score = 0;
            foreach (var piece in _board.CapturedPieces)
            {
                if (piece.Player == Player.Black)
                {
                    score += scoresDict[piece.GetName()];
                }
            }

            return score;
        }

        public int GetBlackScore()
        {
            var score = 0;
            foreach (var piece in _board.CapturedPieces)
            {
                if (piece.Player == Player.White)
                {
                    score += scoresDict[piece.GetName()];
                }
            }

            return score;
        }
    }
}