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
            return 0;
        }

        public int GetBlackScore()
        {
            // Should add up the value of all of the pieces that black has taken.
            return 0;
        }
    }
}