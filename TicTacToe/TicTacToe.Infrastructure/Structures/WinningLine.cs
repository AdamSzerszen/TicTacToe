using System.Collections.Generic;

namespace TicTacToe.Infrastructure.Structures
{
    public class WinningLine
    {
        public List<Coordinates> Content { get; }

        public WinningLine(Coordinates one, Coordinates two, Coordinates three)
        {
            Content = new List<Coordinates>
            {
                one, two, three
            };
        }
    }
}