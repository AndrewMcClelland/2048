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
    public partial class WelcomeScreen : UserControl
    {
        public event EventHandler GameStarted;

        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler handler = GameStarted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
