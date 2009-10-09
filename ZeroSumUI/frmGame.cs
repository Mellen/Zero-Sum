using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZeroSumGame;
using ZeroSumGamePieces;

namespace NumbersGame
{
    public partial class frmGame : Form
    {
        private Game game;
        public frmGame()
        {
            game = new Game();
            game.LoadNumber += LoadNextNumber;
            game.MoveNumber += MoveCurrentNumber;
            game.GameOverEvent += GameOver;
            game.ScoreChange += ScoreUpdate;
            game.RemoveEvent += RemoveNumbers;
            InitializeComponent();
            tmrPlay.Tick += game.GameStep;
            scMain.KeyUp += game.KeyUp;
        }

        private void RemoveNumbers(ZeroSumEventArgs e)
        {
            foreach (Number n in e.numbers)
            {
                if (pnlGame.Controls.Contains(n.Display))
                {
                    pnlGame.Controls.Remove(n.Display);
                }
            }
        }

        private void GameOver()
        {
            lblGameOver.Visible = true;
            tmrPlay.Enabled = false;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnUnpause.Enabled = false;
        }

        private void ScoreUpdate(ScoreChangeEventArgs e)
        {
            lblScore.Text = e.NewScore.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblGameOver.Visible = false;
            game.Start();
            btnStart.Enabled = false;
            tmrPlay.Enabled = true;
            btnPause.Enabled = true;
            scMain.Focus();
        }

        private void MoveCurrentNumber(LoadNumberEventArgs e)
        {
            Number n = e.EventNumber;
            n.Display.Left = n.Column * (pnlGame.Width / Game.ColMax);
            n.Display.Top = n.Row * (pnlGame.Height / Game.RowMax);
        }

        private void LoadNextNumber(LoadNumberEventArgs e)
        {
            Label loadedNum = new Label();
            Number n = e.EventNumber;
            n.Display.Top = 0;
            n.Display.Parent = pnlGame;
            n.Display.Left = n.Column * (pnlGame.Width / Game.ColMax);
            lblNextNumber.Text = game.NextNumber.ToString();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrPlay.Enabled = false;
            game.currentState = GameState.pause;
            btnUnpause.Enabled = true;
            btnPause.Enabled = false;
            lblPause.Visible = true;
        }

        private void btnUnpause_Click(object sender, EventArgs e)
        {
            tmrPlay.Enabled = true;
            game.currentState = GameState.playing;
            btnUnpause.Enabled = false;
            btnPause.Enabled = true;
            lblPause.Visible = false;
            scMain.Focus();
        }

        private void scMain_Leave(object sender, EventArgs e)
        {
            scMain.Focus();
        }
    }
}
