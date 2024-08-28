using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步暂停区别
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient =new HttpClient())
            {
                string s1 = await httpClient.GetStringAsync("https://www.youzack.com");
                textBox1.Text = s1.Substring(0, 100);
                //Thread.Sleep(3000);//3S 用Thread.Sleep暂停的话，会阻塞调用的ui主线程，一触发窗口就卡死了。
                await Task.Delay(3000);//用Task.Delay不会阻塞主线程，窗口可以随时移动
                string s2 = await httpClient.GetStringAsync("https://www.baidu.com");
                textBox1.Text = s2.Substring(0, 100);
            }
        }
    }
}
