using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventlianxi4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.ShowDialog();
        }
    }
    class MyForm:Form//MyForm 事件的响应者
    {
        private TextBox TextBox;
        private Button Button;//拥有者
        public MyForm()
        {
            this.TextBox = new TextBox();
            this.Button = new Button();
            this.Controls.Add(this.Button);
            this.Controls.Add(this.TextBox);
            this.Button.Click += this.ButtonClicked; //Click  事件成员   订阅事件
            this.Button.Text = "Say hello";
            this.Button.Top = 50;
        }

        private void ButtonClicked(object sender, EventArgs e)//事件处理器
        {
            this.TextBox.Text = "Hello,World";
        }
    }
}
