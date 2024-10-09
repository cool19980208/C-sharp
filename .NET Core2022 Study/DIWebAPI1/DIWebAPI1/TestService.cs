using System.IO;

namespace DIWebAPI1
{
    public class TestService
    {
        private string[] files;
        public TestService()
        {
            this.files = Directory.GetFiles("D:\\Program Files (x86)", "*.exe", SearchOption.AllDirectories);//扫描某目录的所有exe文件
        }
        public int Count
        {
            get { return this.files.Length; }
        }
    }
}
