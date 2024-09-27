using System;
using System.Linq;
using System.Linq.Expressions;
using ExpressionTreeToString;
using static System.Linq.Expressions.Expression;

namespace 表达式树1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var b = Parameter(typeof(Book), "b");

               var expr= Lambda<Func<Book,bool>>(
                    GreaterThan(MakeMemberAccess(b, typeof(Book).GetProperty("Price")), Constant(5.0)),b
                );//+上<Func<Book,bool>  和Constant(5)变成5.0，这个版本没有考虑类型转换的问题
                using (MyDbContext ctx = new MyDbContext())
                {
                    ctx.Books.Where(expr).ToArray();
                }*/

            Console.WriteLine("请选择输出筛选方式~ 1：大于  2：小于");
            string s = Console.ReadLine();
            var b = Parameter(typeof(Book), "b");
            var exprPrice = MakeMemberAccess(b, typeof(Book).GetProperty("Price"));
            var const5 = Constant(5.0);
            BinaryExpression exprCompare;
            if (s=="1")
            {
                exprCompare = GreaterThan(exprPrice, const5);
            }
            else
            {
                exprCompare = LessThan(exprPrice, const5);
            }
            var expr = Lambda<Func<Book, bool>>(exprCompare, b);
            using (MyDbContext ctx = new MyDbContext())
            {
                ctx.Books.Where(expr).ToArray();
            }
            //Console.WriteLine(expr.ToString("Object notation", "C#"));
        }

        static void Main2(string[] args)
        {
            Expression<Func<Book, bool>> e1 = b => b.Price > 5;
            //Expression<Func<Book, Book, double>> e2 = (b1, b2) => b1.Price + b2.Price;
            ///Func<Book, bool> f1 = b => { return b.Price > 5; };

            //Console.WriteLine(e1.ToString("Object notation", "C#"));
            //Console.WriteLine(e1.ToString("Factory methods", "C#"));
            /*ParameterExpression paramExprB = Expression.Parameter(typeof(Book), "b"); //参数节点
            ConstantExpression constExpr5 = Expression.Constant(5.0, typeof(double)); //创建对应5这个常量的节点
            MemberExpression memExprPrice = Expression.MakeMemberAccess(paramExprB,
                typeof(Book).GetProperty("Price")); //创建访问b的Price属性操作的节点
            BinaryExpression binExoGreatreThan = Expression.GreaterThan(memExprPrice, constExpr5);
            Expression<Func<Book, bool>> expr1 = Expression.Lambda<Func<Book, bool>>(binExoGreatreThan, paramExprB);

            using (MyDbContext ctx = new MyDbContext())
            {
                ctx.Books.Where(expr1).ToArray();
            }*/
        }
    }
}
