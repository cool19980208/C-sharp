using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventlianxi3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();//使用者 和 响应者
            form.Click += form.FormClicked;// 事件：Click   订阅事件
            form.ShowDialog();
        }
    }
    class MyForm : Form //派生  继承
    {
        internal void FormClicked(object sender, EventArgs e)//事件处理器
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
