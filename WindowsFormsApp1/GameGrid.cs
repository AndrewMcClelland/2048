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
	public partial class GameGrid : UserControl
	{
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public GameGrid()
		{
			InitializeComponent();
            spawnTile();
            spawnTile();
            this.Focus();

        }

        public int getTileValue(int x, int y)
        {
            GameTile tile = (GameTile)this.tableLayoutPanel.GetControlFromPosition(x, y);
            return tile.Value;
        }

        public void setTileValue(int x, int y, int value)
        {
            GameTile tile = (GameTile)this.tableLayoutPanel.GetControlFromPosition(x, y);
            tile.Value = value;
        }

        public void UserInput(object sender, KeyEventArgs e)
        {
            shiftTiles(e.KeyCode);
            spawnTile();
            calculateScore();
            //check for lose
        }

        private void shiftTiles(Keys keyCode)
        {
            if (keyCode == Keys.W)
                ;
            else if (keyCode == Keys.A)
                ;
            else if (keyCode == Keys.S)
                ;
            else if (keyCode == Keys.D)
                ;
        }

        private void spawnTile()
        {
            Random rnd = new Random();
            int tileValue = rnd.Next(1, 3) * 2;
            int x;
            int y;
            do
            {
                x = rnd.Next(0, 4);
                y = rnd.Next(0, 4);
            } while (getTileValue(x, y) != 0);

            setTileValue(x, y, tileValue);
        }

        private int currentScore = 0;
        public int CurrentScore
        {
            get
            {
                return currentScore;
            }
            private set
            {
                currentScore = value;
            }
        }
        private void calculateScore()
        {
            int score = getTileValue(0, 0) + getTileValue(1, 0) + getTileValue(2, 0) + getTileValue(3, 0) +
                        getTileValue(0, 1) + getTileValue(1, 1) + getTileValue(2, 1) + getTileValue(3, 1) +
                        getTileValue(0, 2) + getTileValue(1, 2) + getTileValue(2, 2) + getTileValue(3, 2) +
                        getTileValue(0, 3) + getTileValue(1, 3) + getTileValue(2, 3) + getTileValue(3, 3);
            CurrentScore = score;
            OnPropertyChanged("Score");
        }

        private bool isGameOver()
        {
            return false;
        }
    }
}
