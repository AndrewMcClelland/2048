using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GameScreen : UserControl
    {
        public event EventHandler GameOver;

        private void OnGameOver(EventArgs e)
        {
            EventHandler handler = GameOver;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public int Score
        {
            get
            {
                return Convert.ToInt16(scoreLabel.Text);
            }
            private set
            {
                scoreLabel.Text = value.ToString();
            }
        }

        public GameScreen(MainForm hostForm)
        {
            InitializeComponent();
            hostForm.UserKeyInput += this.gameGrid.UserInput;
            gameGrid.PropertyChanged += NewGridEvent;
        }

        public void NewGridEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Score"))
                Score = gameGrid.CurrentScore;
            else if (e.PropertyName.Equals("GameOver"))
                OnGameOver(new EventArgs());
        }

        public void UserInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                shiftTiles(e.KeyCode);
                spawnTile();
                if (isGameOver())
                    OnGameOver(new EventArgs());
            }     
        }

        private void shiftTiles(Keys keyCode)
        {
            if (keyCode == Keys.Right)
                ;
            else if (keyCode == Keys.Left)
                ;
            else if (keyCode == Keys.Up)
                ;
            else if (keyCode == Keys.Down)
                ;
        }

        private void spawnTile()
        {
            GameTile tile = new GameTile();
            Random rnd = new Random();
            int[] possibleValues = { 2, 4 };
            do
            {
                int x = rnd.Next(0, 4);
                int y = rnd.Next(0, 4);
                tile = (GameTile)gameGrid.tableLayoutPanel.GetControlFromPosition(x, y);
            } while (tile.Value != 0);

            tile.Value = possibleValues[rnd.Next(possibleValues.Length)];
        }

        private bool isGameOver()
        {
            return false;
        }

    }
}
