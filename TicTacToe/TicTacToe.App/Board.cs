using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe.Infrastructure.Structures;
using TicTacToe.Infrastructure.Controls;

namespace TicTacToe.App
{
    public partial class Board : Form
    {
        private List<FieldButton> _fields;
        private Label _statusLabel;
        private const int BoardWidth = 320;
        private const int BoardHeight = 320;
        private readonly GameEngine _game;
       
        public Board()
        {
            _fields = new List<FieldButton>();
            InitializeComponent();
            _game = new GameEngine(_fields, _statusLabel);
            SetUpFields();
        }

        private void SetUpFields()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    var coords = new Coordinates(i, j);
                    var field = new FieldButton(coords, _game);
                    _fields.Add(field);
                }
            }

            foreach (var fieldButton in _fields)
            {
                Controls.Add(fieldButton);

            }
        }
    }
}
