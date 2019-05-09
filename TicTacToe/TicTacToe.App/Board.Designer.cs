using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe.App
{
    partial class Board
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(BoardWidth, BoardHeight);
            this.Text = "Board";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            _statusLabel = new Label();
            _statusLabel.Font =  new Font("Arial", 14, FontStyle.Bold);

            this.Controls.Add(_statusLabel);
        }

        #endregion
    }
}

