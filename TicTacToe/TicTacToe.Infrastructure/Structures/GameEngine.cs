using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe.Infrastructure.Controls;
using TicTacToe.Infrastructure.Interfaces;

namespace TicTacToe.Infrastructure.Structures
{
    public class GameEngine: IGameEngine
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;
        private readonly List<FieldButton> _fields;
        private readonly IWinChecker _checker;

        private readonly Label _status;
        private int _roundNumber;

        public virtual Player CurrentPlayer { get; set; }

        public GameEngine()
        {
        }

        public GameEngine(List<FieldButton> fields, Label status)
        {
            _status = status;
            _fields = fields;
            _playerOne = new Player('X', 1);
            _playerTwo = new Player('O', 2);
            _checker = new WinChecker(fields, this);
            StartGame();
        }

        public void PlayerMove()
        {
            var playerWon = _checker.CheckIfWon();
            if (playerWon)
            {
                MessageBox.Show($"{CurrentPlayer.ToString()} won!");
                FinishGame();
            }
            else
            {
                PlayTurn();
                if (_roundNumber > 9)
                {
                    MessageBox.Show("It's a draw!");
                    FinishGame();
                }
            }
        }

        private void StartGame()
        {
            CurrentPlayer = _playerOne;
            UpdateStatus();
            _roundNumber = 1;
            foreach (var fieldButton in _fields)
            {
                fieldButton.ResetContent();
            }
        }

        private void UpdateStatus()
        {
            _status.Text = $"{CurrentPlayer.ToString()} turn!";
        }

        private void SwitchPlayer()
        {
            if (CurrentPlayer.PlayerNumber == _playerOne.PlayerNumber)
            {
                CurrentPlayer = _playerTwo;
            }
            else
            {
                CurrentPlayer = _playerOne;
            }
            UpdateStatus();
        }

        private void PlayTurn()
        {
            SwitchPlayer();
            _roundNumber++;
        }

        private void FinishGame()
        {
            var dialogResult = MessageBox.Show("Play new game?", "Game finished!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                StartGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }
    }
}