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
            if(e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
                UserMove(e.KeyCode);
        }

        private void UserMove(Keys keyCode)
        {
            shiftTiles(keyCode);
            spawnTile();
            calculateScore();
            checkForGameOver();
        }

        private void shiftTiles(Keys keyCode)
        {
            int x,y;
            int[] lane = new int[4];
            if (keyCode == Keys.W)
            {
                for (x = 0; x < 4; x++) //cols
                {
                    for (y = 0; y < 4; y++) 
                    {
                        lane[y] = getTileValue(x, y);
                    }
                    lane = mergeLane(lane);
                    for (y = 0; y < 4; y++)
                    {
                        setTileValue(x, y, lane[y]);
                    }
                }
                
            }
            else if (keyCode == Keys.A)
            {
                for(y = 0; y < 4; y++) //rows
                {
                    for (x = 0; x < 4; x++) 
                    {
                        lane[x] = getTileValue(x, y);
                    }
                    lane = mergeLane(lane);
                    for (x = 0; x < 4; x++)
                    {
                        setTileValue(x, y, lane[x]);
                    }
                }
                
            }
            else if (keyCode == Keys.S) 
            {
                for (x = 0; x < 4; x++) //cols
                {
                    for (y = 0; y < 4; y++)
                    {
                        lane[y] = getTileValue(x, y);
                    }
                    Array.Reverse(lane);
                    lane = mergeLane(lane);
                    Array.Reverse(lane);
                    for (y = 0; y < 4; y++)
                    {
                        setTileValue(x, y, lane[y]);
                    }
                }
                
            }
            else if (keyCode == Keys.D) 
            {
                for (y = 0; y < 4; y++) //rows
                {
                    for (x = 0; x < 4; x++)
                    {
                        lane[x] = getTileValue(x, y);
                    }
                    Array.Reverse(lane);
                    lane = mergeLane(lane);
                    Array.Reverse(lane);
                    for (x = 0; x < 4; x++)
                    {
                        setTileValue(x, y, lane[x]);
                    }
                }
                
            }
        }

        private int[] mergeLane(int[] lane)
        {
            int current_index, next_index, current_val, next_val;

            for (int i = 0; i < 3; i++)
            {
                current_index = i;
                next_index = i + 1;
                current_val = lane[current_index];
                next_val = lane[next_index];

                while (true)
                {
                    if (next_val == 0)
                    {
                        if (next_index == 3)
                            break;
                        next_index++;
                        next_val = lane[next_index];
                    }
                    else if(current_val == 0)
                    {
                        lane[current_index] = current_val + next_val;
                        lane[next_index] = 0;
                        
                        if (next_index == 3)
                            break;
                        current_index++;
                        current_val = lane[current_val];
                        next_index++;
                        next_val = lane[next_index];
                    }
                    else if (current_val == next_val)
                    {
                        lane[current_index] = current_val + next_val;
                        lane[next_index] = 0;
                        break;

                    }
                    else if (current_val != next_val)
                        break;
                } // end while
            } // end loop
            return lane;
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

        private bool gameOver = false;
        public bool GameOver
        {
            get
            {
                return GameOver;
            }
            private set
            {
                GameOver = value;
            }
        }
        private bool checkForGameOver()
        {
            bool isEmptySpace = false;
            int x, y, currentvalue;
            for (x = 0; x < 4; x++)
            {
                for (y = 0; y < 4; y++)
                {
                    if (getTileValue(x, y) != 0)
                    {
                        return true;
                    }
                }
            }
            for (x = 0; x < 4; x++) 
            {
                for (y = 0; y < 4; y++)
                {
                    //Check above
                    if (y != 0)
                        if (getTileValue(x, y) == getTileValue(x, y - 1))
                            return true;
                    //Check left
                    if (x != 0)
                        if (getTileValue(x, y) == getTileValue(x - 1, y))
                            return true;
                    //Check down
                    if (y != 3)
                        if (getTileValue(x, y) == getTileValue(x, y + 1))
                            return true;
                    //Check right
                    if (x != 3)
                        if (getTileValue(x, y) == getTileValue(x + 1, y))
                            return true;
                }
            }
            return false;
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
        { int score =   getTileValue(0, 0) + getTileValue(1, 0) + getTileValue(2, 0) + getTileValue(3, 0) +
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
