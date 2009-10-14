namespace NumbersGame
{
    partial class frmGame
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.lblPause = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pnlHS = new System.Windows.Forms.Panel();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.lblHS = new System.Windows.Forms.Label();
            this.pnlLevel = new System.Windows.Forms.Panel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLev = new System.Windows.Forms.Label();
            this.btnUnpause = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnlScore = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreLabel = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlNextNumberPanel = new System.Windows.Forms.Panel();
            this.pnlNextNumber = new System.Windows.Forms.Panel();
            this.lblNextNumber = new System.Windows.Forms.Label();
            this.lblNextNumberLabel = new System.Windows.Forms.Label();
            this.tmrPlay = new System.Windows.Forms.Timer(this.components);
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlGame.SuspendLayout();
            this.pnlHS.SuspendLayout();
            this.pnlLevel.SuspendLayout();
            this.pnlScore.SuspendLayout();
            this.pnlNextNumberPanel.SuspendLayout();
            this.pnlNextNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.White;
            this.scMain.Panel1.Controls.Add(this.pnlGame);
            this.scMain.Panel1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.btnHelp);
            this.scMain.Panel2.Controls.Add(this.btnAbout);
            this.scMain.Panel2.Controls.Add(this.btnRestart);
            this.scMain.Panel2.Controls.Add(this.pnlHS);
            this.scMain.Panel2.Controls.Add(this.pnlLevel);
            this.scMain.Panel2.Controls.Add(this.btnUnpause);
            this.scMain.Panel2.Controls.Add(this.btnPause);
            this.scMain.Panel2.Controls.Add(this.pnlScore);
            this.scMain.Panel2.Controls.Add(this.btnStart);
            this.scMain.Panel2.Controls.Add(this.pnlNextNumberPanel);
            this.scMain.Size = new System.Drawing.Size(334, 483);
            this.scMain.SplitterDistance = 194;
            this.scMain.TabIndex = 0;
            this.scMain.Leave += new System.EventHandler(this.scMain_Leave);
            // 
            // pnlGame
            // 
            this.pnlGame.Controls.Add(this.lblPause);
            this.pnlGame.Controls.Add(this.lblGameOver);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(194, 483);
            this.pnlGame.TabIndex = 0;
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPause.Location = new System.Drawing.Point(49, 239);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(96, 27);
            this.lblPause.TabIndex = 1;
            this.lblPause.Text = "Paused";
            this.lblPause.Visible = false;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(28, 239);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(138, 27);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "Game Over";
            this.lblGameOver.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(31, 268);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(31, 239);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.TabStop = false;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Location = new System.Drawing.Point(31, 455);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.TabStop = false;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pnlHS
            // 
            this.pnlHS.Controls.Add(this.lblHighScore);
            this.pnlHS.Controls.Add(this.lblHS);
            this.pnlHS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHS.Location = new System.Drawing.Point(0, 146);
            this.pnlHS.Name = "pnlHS";
            this.pnlHS.Size = new System.Drawing.Size(136, 38);
            this.pnlHS.TabIndex = 7;
            // 
            // lblHighScore
            // 
            this.lblHighScore.BackColor = System.Drawing.Color.White;
            this.lblHighScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHighScore.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.Location = new System.Drawing.Point(0, 18);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(136, 20);
            this.lblHighScore.TabIndex = 1;
            this.lblHighScore.Text = "0";
            this.lblHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHS
            // 
            this.lblHS.AutoSize = true;
            this.lblHS.Location = new System.Drawing.Point(0, 3);
            this.lblHS.Name = "lblHS";
            this.lblHS.Size = new System.Drawing.Size(60, 13);
            this.lblHS.TabIndex = 0;
            this.lblHS.Text = "High Score";
            // 
            // pnlLevel
            // 
            this.pnlLevel.Controls.Add(this.lblLevel);
            this.pnlLevel.Controls.Add(this.lblLev);
            this.pnlLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLevel.Location = new System.Drawing.Point(0, 112);
            this.pnlLevel.Name = "pnlLevel";
            this.pnlLevel.Size = new System.Drawing.Size(136, 34);
            this.pnlLevel.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.BackColor = System.Drawing.Color.White;
            this.lblLevel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLevel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(0, 13);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(136, 21);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "0";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLev
            // 
            this.lblLev.AutoSize = true;
            this.lblLev.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLev.Location = new System.Drawing.Point(0, 0);
            this.lblLev.Name = "lblLev";
            this.lblLev.Size = new System.Drawing.Size(33, 13);
            this.lblLev.TabIndex = 0;
            this.lblLev.Text = "Level";
            // 
            // btnUnpause
            // 
            this.btnUnpause.Enabled = false;
            this.btnUnpause.Location = new System.Drawing.Point(31, 371);
            this.btnUnpause.Name = "btnUnpause";
            this.btnUnpause.Size = new System.Drawing.Size(75, 23);
            this.btnUnpause.TabIndex = 4;
            this.btnUnpause.TabStop = false;
            this.btnUnpause.Text = "Resume";
            this.btnUnpause.UseVisualStyleBackColor = true;
            this.btnUnpause.Click += new System.EventHandler(this.btnUnpause_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(31, 400);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.TabStop = false;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pnlScore
            // 
            this.pnlScore.Controls.Add(this.lblScore);
            this.pnlScore.Controls.Add(this.lblScoreLabel);
            this.pnlScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScore.Location = new System.Drawing.Point(0, 74);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(136, 38);
            this.pnlScore.TabIndex = 2;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.White;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblScore.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(0, 18);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(136, 20);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScoreLabel
            // 
            this.lblScoreLabel.AutoSize = true;
            this.lblScoreLabel.Location = new System.Drawing.Point(3, 3);
            this.lblScoreLabel.Name = "lblScoreLabel";
            this.lblScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.lblScoreLabel.TabIndex = 0;
            this.lblScoreLabel.Text = "Score";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(31, 429);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlNextNumberPanel
            // 
            this.pnlNextNumberPanel.Controls.Add(this.pnlNextNumber);
            this.pnlNextNumberPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNextNumberPanel.Location = new System.Drawing.Point(0, 0);
            this.pnlNextNumberPanel.Name = "pnlNextNumberPanel";
            this.pnlNextNumberPanel.Size = new System.Drawing.Size(136, 74);
            this.pnlNextNumberPanel.TabIndex = 0;
            // 
            // pnlNextNumber
            // 
            this.pnlNextNumber.Controls.Add(this.lblNextNumber);
            this.pnlNextNumber.Controls.Add(this.lblNextNumberLabel);
            this.pnlNextNumber.Location = new System.Drawing.Point(31, 12);
            this.pnlNextNumber.Name = "pnlNextNumber";
            this.pnlNextNumber.Size = new System.Drawing.Size(75, 59);
            this.pnlNextNumber.TabIndex = 2;
            // 
            // lblNextNumber
            // 
            this.lblNextNumber.BackColor = System.Drawing.Color.White;
            this.lblNextNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextNumber.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextNumber.Location = new System.Drawing.Point(0, 13);
            this.lblNextNumber.Name = "lblNextNumber";
            this.lblNextNumber.Size = new System.Drawing.Size(75, 46);
            this.lblNextNumber.TabIndex = 1;
            this.lblNextNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNextNumberLabel
            // 
            this.lblNextNumberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNextNumberLabel.Location = new System.Drawing.Point(0, 0);
            this.lblNextNumberLabel.Name = "lblNextNumberLabel";
            this.lblNextNumberLabel.Size = new System.Drawing.Size(75, 13);
            this.lblNextNumberLabel.TabIndex = 0;
            this.lblNextNumberLabel.Text = "Next Number";
            this.lblNextNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrPlay
            // 
            this.tmrPlay.Interval = 400;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 483);
            this.Controls.Add(this.scMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zero Sum";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGame_FormClosed);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.pnlHS.ResumeLayout(false);
            this.pnlHS.PerformLayout();
            this.pnlLevel.ResumeLayout(false);
            this.pnlLevel.PerformLayout();
            this.pnlScore.ResumeLayout(false);
            this.pnlScore.PerformLayout();
            this.pnlNextNumberPanel.ResumeLayout(false);
            this.pnlNextNumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel pnlNextNumberPanel;
        private System.Windows.Forms.Label lblNextNumberLabel;
        private System.Windows.Forms.Label lblNextNumber;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrPlay;
        private System.Windows.Forms.Panel pnlNextNumber;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreLabel;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnUnpause;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Panel pnlLevel;
        private System.Windows.Forms.Panel pnlHS;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Label lblHS;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLev;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnHelp;
    }
}

