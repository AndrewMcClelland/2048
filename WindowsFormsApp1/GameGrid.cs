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
            int tileValue = rnd.Next(1, 2) * 2;
            int x;
            int y;
            do
            {
                x = rnd.Next(0, 4);
                y = rnd.Next(0, 4);
            } while (getTileValue(x, y) != 0);

            setTileValue(x, y, tileValue);
        }

        private bool isGameOver()
        {
            return false;
        }
    }
}
