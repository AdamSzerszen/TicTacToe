namespace TicTacToe.Infrastructure.Structures
{
    public struct Coordinates
    {
        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator !=(Coordinates one, Coordinates two)
        {
            return one.X != two.X|| one.Y != two.Y;
        }

        public static bool operator ==(Coordinates one, Coordinates two)
        {
            return one.X == two.X && one.Y == two.Y;
        }
    }
}