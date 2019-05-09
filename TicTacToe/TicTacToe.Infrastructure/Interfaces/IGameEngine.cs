using TicTacToe.Infrastructure.Structures;

namespace TicTacToe.Infrastructure.Interfaces
{
    public interface IGameEngine
    {
        Player CurrentPlayer { get; set; }
    }
}