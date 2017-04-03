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
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen(int score)
        {
            InitializeComponent();
            scoreLabel.Text = score.ToString();
        }

        public event EventHandler PlayAgain;

        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler handler = PlayAgain;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
