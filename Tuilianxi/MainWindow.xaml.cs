using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tuilianxi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Window> winList;
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            winList = new List<Window>();  //实例化
            for (int i = 0; i < 15000; i++)
            {
                Window w = new Window();   //15000次的实例化，慢慢存放在堆上去
                winList.Add(w);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            winList.Clear();//清除winList的实例化
        }
    }
}
