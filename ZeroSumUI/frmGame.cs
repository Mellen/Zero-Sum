using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZeroSumGame;
using ZeroSumGamePieces;

namespace NumbersGame
{
    /// <summary>
    /// User Interface for the Zero Sum game.
    /// </summary>
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
            game.HighScoreUpdate += HighScoreUpdate;
            game.LevelUp += LevelUp;
            InitializeComponent();
            tmrPlay.Tick += game.GameStep;
            scMain.KeyUp += game.KeyUp;
            lblHighScore.Text = game.HighScore.ToString();
        }

        /// <summary>
        /// Event handler for Number OnRemove events.
        /// </summary>
        /// <param name="e">Contains the Number that's fired the event</param>
        private void RemoveNumber(RemoveEventArgs e)
        {
            if (pnlGame.Controls.Contains(e.number.Display))
            {
                pnlGame.Controls.Remove(e.number.Display);
            }
        }

        /// <summary>
        /// Called when the game is over.
        /// </summary>
        private void GameOver()
        {
            lblGameOver.Visible = true;
            tmrPlay.Enabled = false;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnUnpause.Enabled = false;
            btnRestart.Enabled = false;
        }

        /// <summary>
        /// Updates the score dislayed.
        /// </summary>
        /// <param name="e">Contains the new score</param>
        private void ScoreUpdate(ScoreChangeEventArgs e)
        {
            lblScore.Text = e.NewScore.ToString();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <param name="sender">Sender of the request</param>
        /// <param name="e">Event arguments</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblGameOver.Visible = false;
            game.Start();
            btnStart.Enabled = false;
            tmrPlay.Enabled = true;
            btnPause.Enabled = true;
            btnRestart.Enabled = true;
            pnlGame.Focus();
            scMain.Select();
            
        }

        /// <summary>
        /// Places the number on the screen.
        /// </summary>
        /// <param name="e">Contains the number being moved</param>
        private void MoveCurrentNumber(LoadNumberEventArgs e)
        {
            Number n = e.EventNumber;
            n.Display.Left = n.Column * (pnlGame.Width / Game.ColMax);
            n.Display.Top = n.Row * (pnlGame.Height / Game.RowMax);
        }

        /// <summary>
        /// Loads the number onto the screen.
        /// </summary>
        /// <param name="e">Contains the number being loaded</param>
        private void LoadNextNumber(LoadNumberEventArgs e)
        {
            Label loadedNum = new Label();
            Number n = e.EventNumber;
            n.OnRemove += RemoveNumber;
            n.Display.Top = 0;
            n.Display.Parent = pnlGame;
            n.Display.Left = n.Column * (pnlGame.Width / Game.ColMax);
            lblNextNumber.Text = game.NextNumber.ToString();
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        /// <param name="sender">Object that send the request</param>
        /// <param name="e">Event arguments</param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            tmrPlay.Enabled = false;
            game.currentState = GameState.pause;
            btnUnpause.Enabled = true;
            btnPause.Enabled = false;
            lblPause.Visible = true;
        }

        /// <summary>
        /// Resumes the game.
        /// </summary>
        /// <param name="sender">Object that send the request</param>
        /// <param name="e">Event arguments</param>
        private void btnUnpause_Click(object sender, EventArgs e)
        {
            tmrPlay.Enabled = true;
            game.currentState = GameState.playing;
            btnUnpause.Enabled = false;
            btnPause.Enabled = true;
            lblPause.Visible = false;
            pnlGame.Focus();
            scMain.Select();
        }

        private void scMain_Leave(object sender, EventArgs e)
        {
            scMain.Select();
        }

        /// <summary>
        /// Updates the High Score display.
        /// </summary>
        private void HighScoreUpdate()
        {
            lblHighScore.Text = game.HighScore.ToString();
        }

        /// <summary>
        /// Updates the Level display and speeds up the game.
        /// </summary>
        /// <param name="e">Contains the value of the new level</param>
        private void LevelUp(LevelUpArgs e)
        {
            if (tmrPlay.Interval > 40)
            {
                tmrPlay.Interval -= 10;
            }
            lblLevel.Text = e.level.ToString();
        }

        /// <summary>
        /// Handles the OnClose even.
        /// Makes sure the game ends.
        /// </summary>
        /// <param name="sender">Object that send the request</param>
        /// <param name="e">Event arguments</param>
        private void frmGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.GameOver();
        }

        /// <summary>
        /// Restarts the game.
        /// </summary>
        /// <param name="sender">Object that send the request</param>
        /// <param name="e">Event arguments</param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            game.Restart();
            btnStart_Click(sender, e);
            scMain.Select();
        }

        /// <summary>
        /// Loads the about box.
        /// </summary>
        /// <param name="sender">Object that send the request</param>
        /// <param name="e">Event arguments</param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
            pnlGame.Focus();
            scMain.Select();
        }

        /// <summary>
        /// Loads the help file.
        /// </summary>
        /// <param name="sender">Object that send the request</param>
        /// <param name="e">Event arguments</param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("help.htm");
            }
            catch (Exception)
            {
                MessageBox.Show("Help file not found.");
            }
            pnlGame.Focus();
            scMain.Select();
        }
    }
}
