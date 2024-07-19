using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexerlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            stu["Math"] = 90;
            var mathScore = stu["Math"];
            Console.WriteLine(mathScore);
        }
    }

    class Student
    {
        private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();

        public int? this[string subject]//索引器
        {
            get 
            {
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    return this.scoreDictionary[subject];//访问属性 要用[]
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                if (value.HasValue==false)
                {
                    throw new Exception("成绩不能为空");
                }
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    this.scoreDictionary[subject] = value.Value;//访问属性 要用[]
                }
                else
                {
                    this.scoreDictionary.Add(subject, value.Value);
                }
            
            }
        }
    }
}
