using System.Collections.Generic;
using System.Windows.Input;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private Board _board;

        private Dictionary<string, int> scoreesDict = new Dictionary<string, int>()
        {
            {"Pawn", 1},
            {"Bishop", 3},
            {"Knight", 3},
            {"Rook", 5},
            {"Queen", 9}
        };

        public ScoreCalculator(Board board)
        {
            _board = board;
        }

        public int GetWhiteScore()
        {
            // Should add up the value of all of the pieces that white has taken.
            return 0;
        }

        public int GetBlackScore()
        {
            // Should add up the value of all of the pieces that black has taken.
            return 0;
        }
    }
}