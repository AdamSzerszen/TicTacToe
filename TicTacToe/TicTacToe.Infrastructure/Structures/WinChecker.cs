using System.Collections.Generic;
using TicTacToe.Infrastructure.Controls;
using TicTacToe.Infrastructure.Interfaces;

namespace TicTacToe.Infrastructure.Structures
{
    public class WinChecker: IWinChecker
    {
        private readonly List<WinningLine> _winningLines;
        private readonly List<FieldButton> _fields;
        private readonly IGameEngine _gameEngine;

        public WinChecker(List<FieldButton> fields, IGameEngine engine)
        {
            _winningLines = new List<WinningLine>();
            _fields = fields;
            _gameEngine = engine;
            SetUpWinningLines();
        }

        public bool CheckIfWon()
        {
            foreach (var winningLine in _winningLines)
            {
                var playerWon = LineWinning(winningLine);
                if (playerWon)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetUpWinningLines()
        {
            _winningLines.Add(new WinningLine(new Coordinates(1, 1), new Coordinates(2, 1), new Coordinates(3, 1)));
            _winningLines.Add(new WinningLine(new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(3, 2)));
            _winningLines.Add(new WinningLine(new Coordinates(1, 3), new Coordinates(2, 3), new Coordinates(3, 3)));

            _winningLines.Add(new WinningLine(new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(1, 3)));
            _winningLines.Add(new WinningLine(new Coordinates(2, 1), new Coordinates(2, 2), new Coordinates(2, 3)));
            _winningLines.Add(new WinningLine(new Coordinates(3, 1), new Coordinates(3, 2), new Coordinates(3, 3)));

            _winningLines.Add(new WinningLine(new Coordinates(1, 1), new Coordinates(2, 2), new Coordinates(3, 3)));
            _winningLines.Add(new WinningLine(new Coordinates(1, 3), new Coordinates(2, 2), new Coordinates(3, 1)));
        }

        private bool LineWinning(WinningLine line)
        {
            foreach (var coordinate in line.Content)
            {
                var fieldInLine = _fields.Find(field => field.Coordinates == coordinate);
                if (fieldInLine == null || fieldInLine.Text != _gameEngine.CurrentPlayer.PlayerSign.ToString())
                    return false;
            }

            return true;
        }
    }
}