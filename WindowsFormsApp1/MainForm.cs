using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApp1
{
	public partial class MainForm : Form
	{
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public event KeyEventHandler UserKeyInput;
        private GameScreen gameScreen;

        private void OnUserKeyInput(KeyEventArgs e)
        {
            KeyEventHandler handler = UserKeyInput;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public MainForm()
		{
			InitializeComponent();
            player.URL = "BackroundMusic2.mp3";
            welcomeScreen.GameStarted += startGame;
            this.Focus();
        }

        private void startGame(object sender, EventArgs e)
        {
            player.controls.play();
            Controls.Clear();
            gameScreen = new GameScreen(this);
            Controls.Add(gameScreen);
            gameScreen.GameOver += endGame;
            this.Focus();
        }

        private void endGame(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Controls.Clear();
            GameOverScreen gameOverScreen = new GameOverScreen(gameScreen.Score);
            Controls.Add(gameOverScreen);
            gameOverScreen.PlayAgain += startGame;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            OnUserKeyInput(e);
        }
    }
}
