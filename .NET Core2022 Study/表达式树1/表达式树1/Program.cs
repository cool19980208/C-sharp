using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionTreeToString;
using static System.Linq.Expressions.Expression;
using System.Linq.Dynamic.Core;

namespace 表达式树1
{
    class Program
    {
        static void Main(string[] args)
        {
/*            foreach (var b in QueryBooks(null, 3, 200, 1))
            {
                Console.WriteLine(b);
            }

            Book[] QueryBooks(string title, double? lowerPrice, double? upperPrice, int orderByType)
            {
                using (MyDbContext ctx = new MyDbContext())
                {
                                      IQueryable<Book> source = ctx.Books;
                                        if (!string.IsNullOrEmpty(title))
                                        {
                                            source = source.Where(b => b.Title.Contains(title));

                                        }
                                        if (lowerPrice != null)
                                        {
                                            source = source.Where(b => b.Price >= lowerPrice);
                                        }
                                        if (upperPrice != null)
                                        {
                                            source = source.Where(b => b.Price <= upperPrice);
                                        }
                                        if (orderByType == 1)
                                        {
                                            source = source.OrderByDescending(b => b.Price);
                                        }
                                        else if (orderByType == 2)
                                        {
                                            source = source.OrderBy(b => b.Price);
                                        }
                                        return source.ToArray();
                    
                }
               

            }*/
            //拼接字符串创建动态表达式树
            using MyDbContext ctx = new MyDbContext();
           // ctx.Books.Where("Price>=3 and Price <= 60").Select("new(Title,Price)").ToDynamicArray();*/
            //也可以差值字符串来实现
            double price = 5;
            ctx.Books.Where($"Price >={price} and Price <= 60 ").Select("new(Title,Price)").ToDynamicArray();


        }
        static void Main4(string[] args)
        {
            //表达式树
            /*Expression<Func<Book, bool>> expr1 = b => b.Price == 5;
            Expression<Func<Book, bool>> expr2 = b => b.Title == "零基础趣学C语言";
            Console.WriteLine(expr1.ToString("Factory methods", "C#"));//静态的表达式树的结构
            Console.WriteLine(expr2.ToString("Factory methods", "C#"));*/
            /*            QueryBooks("Price", 18.0);
                        QueryBooks("AuthorName", "杨中科");
                        QueryBooks("Title", "零基础趣学C语言");
                        IEnumerable<Book> QueryBooks(string propName, object value)
                        {
                            Type type = typeof(Book);
                            PropertyInfo propInfo = type.GetProperty(propName);
                            Type propType = propInfo.PropertyType;
                            var b = Parameter(typeof(Book), "b");
                            Expression<Func<Book, bool>> expr;
                            if (propType.IsPrimitive)//如果是int、double等基本数据类型
                            {
                                expr = Lambda<Func<Book, bool>>(Equal(
                                        MakeMemberAccess(b, typeof(Book).GetProperty(propName)),
                                        Constant(value)), b);
                            }
                            else//如果是string等类型
                            {
                                expr = Lambda<Func<Book, bool>>(MakeBinary(ExpressionType.Equal,
                                        MakeMemberAccess(b, typeof(Book).GetProperty(propName)),
                                        Constant(value), false, propType.GetMethod("op_Equality")
                                    ), b);
                            }
                            MyDbContext ctx = new MyDbContext();
                            return ctx.Books.Where(expr).ToArray();*/

            //5.3.8	不用Emit生成IL代码实现Select的动态化


            var items = Query<Book>(new string[] { "Id", "PubTime", "Title" });
            foreach (object[] row in items)
            {
                long id = (long)row[0];
                DateTime pubTime = (DateTime)row[1];
                string title = (string)row[2];
                Console.WriteLine(id + "," + pubTime + "," + title);
            }
            IEnumerable<object[]> Query<TEntity>(string[] propNames) where TEntity : class
            {
                ParameterExpression exParameter = Expression.Parameter(typeof(TEntity));
                List<Expression> exProps = new List<Expression>();//数组节点
                foreach (string propName in propNames)
                {
                    Expression exProp = Expression.Convert(Expression.MakeMemberAccess(
                        exParameter, typeof(TEntity).GetProperty(propName)), typeof(object));//隐式转换
                    exProps.Add(exProp);
                }
                Expression[] initializers = exProps.ToArray();
                NewArrayExpression newArrayExp = Expression.NewArrayInit(typeof(object), initializers);
                var selectExpression = Expression.Lambda<Func<TEntity, object[]>>(newArrayExp, exParameter);//生成Lambda表达式
                using MyDbContext ctx = new MyDbContext();
                IQueryable<object[]> selectQueryable = ctx.Set<TEntity>().Select(selectExpression);
                return selectQueryable.ToArray();
            }

        }
        static void Main3(string[] args)
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
            if (s == "1")
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

