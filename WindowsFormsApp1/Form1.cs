using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{

        public event KeyEventHandler UserKeyInput;

        private void OnUserKeyInput(KeyEventArgs e)
        {
            KeyEventHandler handler = UserKeyInput;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public Form1()
		{
			InitializeComponent();
            welcomeScreen.GameStarted += startGame;
        }

        private void startGame(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(new GameScreen(this));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            OnUserKeyInput(e);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Up)
        //    {
        //        // Handle key at form level.
        //        // Do not send event to focused control by returning true.
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    OnUserKeyInput(e);
                    break;
            }
        }
    }
}
