using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class myForm : Form
    {
        public myForm()
        {
            InitializeComponent();
            this.button3.Click += ( sender,  e) =>
            {
                this.myTextBox.Text = "我是主流的简写写法";
            };
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (sender==this.button1)
            {
                this.myTextBox.Text = "Hello";
            }
            if (sender==this.button2)
            {
                this.myTextBox.Text = "World";
            }
            if (sender == this.button3)
            {
                this.myTextBox.Text = "Cool";
            }
        }
    }
}
