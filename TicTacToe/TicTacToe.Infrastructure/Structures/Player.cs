namespace TicTacToe.Infrastructure.Structures
{
    public struct Player
    {
        public char PlayerSign { get; }
        public int PlayerNumber { get; }

        public Player(char playerSign, int playerNumber)
        {
            PlayerSign = playerSign;
            PlayerNumber = playerNumber;
        }

        public override string ToString()
        {
            return $"Player {PlayerNumber}";
        }
    }
}