using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventlianxi2
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();//事件的拥有者
            Controller controller = new Controller(form);//响应者
            form.ShowDialog();
        }
    }
    class Controller
    {
        private Form form;//字段
        public Controller(Form form)
        {
            if (form !=null)//如果对象是null的，我们是没有办法去访问它的事件
            {
                this.form = form;
                this.form.Click += this.formClicked;//订阅事件    Click是事件
            }
        }

        private void formClicked(object sender, EventArgs e)//事件处理器  Elapsed的事件类型ElapsedEventArgs e  和  Click的事件类型EventArgs e 两者的约定不一样，所以不通用。
        {
            this.form.Text = DateTime.Now.ToString();
        }
    }
}
