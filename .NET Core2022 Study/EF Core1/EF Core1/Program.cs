using System;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //插入数据
            /*using(MyDbContext ctx =new MyDbContext())
            {
                Dog d = new Dog();
                d.Name = "Mimi";
                ctx.Dog.Add(d);//把d对象加入Dog这个逻辑上的表里面
                await ctx.SaveChangesAsync();//把上述的对数据的操作更新到 数据库中
            }*/
            //数据的插入

            using (MyDbContext ctx = new MyDbContext())
            {
                /*var b1 = new Book
                {
                    AuthorName = "杨中科",
                    Title = "零基础趣学C语言",
                    Price = 59.8,
                    PubTime = new DateTime(2019, 3, 1),
                };
                var b2 = new Book
                {
                    AuthorName = "Robert Sedgewick",
                    Title = "算法(第4版)",
                    Price = 99,
                    PubTime = new DateTime(2012, 10, 1),
                };
                var b3 = new Book
                {
                    AuthorName = "吴军",
                    Title = "数学之美",
                    Price = 69,
                    PubTime = new DateTime(2020, 5, 1),
                };
                var b4 = new Book
                {
                    AuthorName = "杨中科",
                    Title = "程序员的SQL金典",
                    Price = 52,
                    PubTime = new DateTime(2008, 9, 1),
                };
                var b5 = new Book
                {
                    AuthorName = "吴军",
                    Title = "文明之光",
                    Price = 246,
                    PubTime = new DateTime(2017, 3, 1),
                };
                ctx.Books.Add(b1);
                ctx.Books.Add(b2);
                ctx.Books.Add(b3);
                ctx.Books.Add(b4);
                ctx.Books.Add(b5);
                await ctx.SaveChangesAsync();*/

                //查询
                /*var books =ctx.Books.Where(b => b.Price > 80);
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }*/
                /*var book1 = ctx.Books.Single(b => b.Title == "零基础趣学C语言");
                Console.WriteLine(book1.Price);*/

                //排序
                /*var books = ctx.Books.OrderByDescending(b => b.Price);
                foreach (var book in books)
                {
                    Console.WriteLine($"Id={book.Id},Title ={book.Title},Price={book.Price}");
                }*/

                /*var groups = ctx.Books.GroupBy(b => b.AuthorName)
                    .Select(g => new
                    {
                        AuthorName = g.Key,
                        BooksCount = g.Count(),
                        MaxPrice = g.Max(b => b.Price),
                    });
                foreach (var g in groups)
                {
                    Console.WriteLine(
                        $"作者名:{g.AuthorName},著作数量:{g.BooksCount},最贵的价格:{g.MaxPrice}"
                    );
                }*/

                //修改
                /*var b = ctx.Books.Single(b => b.Title == "数学之美");
                b.AuthorName = "Jun Wu";
                await ctx.SaveChangesAsync();*/
                //删除
                /*var b = ctx.Books.Single(b => b.Title == "数学之美");
                ctx.Remove(b);//也可以写成ctx.Books.Remove(b);
                await ctx.SaveChangesAsync();*/

                /*  var books = ctx.Books.Where(b => b.Price>10);
                  foreach (var book in books)
                  {
                      book.Price = book.Price + 1;
                  }
                  await ctx.SaveChangesAsync();*/
                // ExecuteUpdate() EFCore7.0 +
                // ctx.Books.Where(b => b.Price > 10).ExecuteUpdate(setter => setter.SetProperty(e => e.Price, e => e.Price + 10));
                /*Guid g = Guid.NewGuid();
                Console.WriteLine(g);
                Console.WriteLine(g.ToString());*/

                /*//Guid算法
                Author a2 = new Author { Name = "Zack Yang" };
                a2.Id = Guid.NewGuid();
                Console.WriteLine($"保存前，Id={a2.Id}");
                ctx.Authors.Add(a2);
                await ctx.SaveChangesAsync();
                Console.WriteLine($"保存后，Id={a2.Id}");*/
                /*IQueryable<Book> books = ctx.Books.Where(b => b.Price > 8);
                Console.WriteLine(books.Count());
                Console.WriteLine(books.Max(b=>b.Price));
                foreach (Book b in books.Where(b=>b.PubTime.Year>2000))
                {
                    Console.WriteLine(b.Title);
                }*/
                PrintPage(1, 2);
                Console.WriteLine("***************");
                PrintPage(2, 2);

            }
        }
        static void PrintPage(int pageIndex,int pageSize)
        {
            using(MyDbContext ctx = new MyDbContext())
            {
                IQueryable<Book> books = ctx.Books.Where(b => b.Title.Contains("1"));
                long count = books.LongCount();//总条数
                long pageCount = (long)Math.Ceiling(count * 1.0 / pageSize);//页数
                Console.WriteLine("页数:"+pageCount);
                var pagedBooks = books.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                foreach (var b in pagedBooks)
                {
                    Console.WriteLine(b.Id+","+b.Title);
                }
            }
        }
    }
}
