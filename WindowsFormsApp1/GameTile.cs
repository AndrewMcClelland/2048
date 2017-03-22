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
	public partial class GameTile : UserControl
	{

        public GameTile()
		{
			InitializeComponent();
		}

        public int Value
        {
            get
            {
                if (label.Text.Equals(" "))
                    return 0;

                return Convert.ToInt16(this.label.Text);
            }
            set { label.Text = value.ToString(); }
        }

        public void UpdateValue(int value)
        {
            this.label.Text = value.ToString();
            switch (value)
            {
                case 0:

                    break;

                case 2:

                    break;

                case 4:

                    break;

                case 8:

                    break;

                case 16:

                    break;

                case 32:

                    break;

                case 64:

                    break;

                case 128:

                    break;

                case 256:

                    break;

                case 512:

                    break;

                case 1024:

                    break;

                case 2048:

                    break;

                default:
                    break;

            }
        }

	}
}
