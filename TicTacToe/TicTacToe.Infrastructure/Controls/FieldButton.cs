using System;
using System.Drawing;
using TicTacToe.Infrastructure.Structures;

namespace TicTacToe.Infrastructure.Controls
{
    public class FieldButton : System.Windows.Forms.Button
    {
        private const int FieldSize = 60;
        private const int FieldMargin = 10;
        private char _content;
        private bool _isTaken;
        private readonly GameEngine _game;

        public Coordinates Coordinates { get; }

        public FieldButton(Coordinates coordinates, GameEngine game, char content = ' ')
        {
            _isTaken = false;
            Coordinates = coordinates;
            _game = game;
            _content = content;

            SetUpControl();
            UpdateField();
        }

        protected override void OnClick(EventArgs e)
        {

            var contentSet = TrySetContent(_game.CurrentPlayer.PlayerSign);
            if (contentSet)
            {
                _game.PlayerMove();
            }
        }

        public void ResetContent()
        {
            _isTaken = false;
            _content = ' ';
            UpdateField();
        }

        private bool TrySetContent(char content)
        {
            if (_isTaken)
                return false;

            _content = content;
            _isTaken = true;

            UpdateField();
            return true;
        }

        private void SetUpControl()
        {
            Size = new Size(FieldSize, FieldSize);
            BackColor = Color.White;
            ForeColor = Color.Black;
            FontHeight = 20;
            Location = new Point(GetLocalisation(Coordinates.X), GetLocalisation(Coordinates.Y));
            TabStop = false;
        }

        private int GetLocalisation(int coordinate)
        {
            return coordinate * FieldSize + FieldMargin;
        }

        private void UpdateField()
        {
            Text = _content.ToString();
            Enabled = !_isTaken;
        }
    }
}