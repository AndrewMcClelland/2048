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
            set
            {
                if(value != 0)
                    label.Text = value.ToString();

                switch (value)
                {
                    case 0:
                        this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        this.label.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        label.Text = " ";
                        break;

                    case 2:
                        this.BackColor = System.Drawing.Color.IndianRed;
                        this.label.BackColor = System.Drawing.Color.IndianRed;
                        label.Font = new Font(label.Font.FontFamily, 36);
                        break;

                    case 4:
                        this.BackColor = System.Drawing.Color.RosyBrown;
                        this.label.BackColor = System.Drawing.Color.RosyBrown;
                        label.Font = new Font(label.Font.FontFamily, 36);
                        break;

                    case 8:
                        this.BackColor = System.Drawing.Color.LightSalmon;
                        this.label.BackColor = System.Drawing.Color.LightSalmon;
                        label.Font = new Font(label.Font.FontFamily, 36);
                        break;

                    case 16:
                        this.BackColor = System.Drawing.Color.SaddleBrown;
                        this.label.BackColor = System.Drawing.Color.SaddleBrown;
                        label.Font =  new Font(label.Font.FontFamily, 24);
                        break;

                    case 32:
                        this.BackColor = System.Drawing.Color.PeachPuff;
                        this.label.BackColor = System.Drawing.Color.PeachPuff;
                        label.Font = new Font(label.Font.FontFamily, 24);
                        break;

                    case 64:
                        this.BackColor = System.Drawing.Color.Tan;
                        this.label.BackColor = System.Drawing.Color.Tan;
                        label.Font = new Font(label.Font.FontFamily, 24);
                        break;

                    case 128:
                        this.BackColor = System.Drawing.Color.PaleGoldenrod;
                        this.label.BackColor = System.Drawing.Color.PaleGoldenrod;
                        label.Font = new Font(label.Font.FontFamily, 18);
                        break;

                    case 256:
                        this.BackColor = System.Drawing.Color.Chartreuse;
                        this.label.BackColor = System.Drawing.Color.Chartreuse;
                        label.Font = new Font(label.Font.FontFamily, 18);
                        break;

                    case 512:
                        this.BackColor = System.Drawing.Color.Brown;
                        this.label.BackColor = System.Drawing.Color.Brown;
                        label.Font = new Font(label.Font.FontFamily, 18);
                        break;

                    case 1024:
                        this.BackColor = System.Drawing.Color.Silver;
                        this.label.BackColor = System.Drawing.Color.Silver;
                        label.Font = new Font(label.Font.FontFamily, 14);
                        break;

                    case 2048:
                        this.BackColor = System.Drawing.Color.Gold;
                        this.label.BackColor = System.Drawing.Color.Gold;
                        label.Font = new Font(label.Font.FontFamily, 14);
                        break;

                    default:
                        break;
                }
            }
        }

    }
}
