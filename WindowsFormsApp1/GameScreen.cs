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

        public GameScreen(Form1 hostForm)
        {
            InitializeComponent();
            hostForm.UserKeyInput += this.gameGrid.UserInput;
        }

        

    }
}
