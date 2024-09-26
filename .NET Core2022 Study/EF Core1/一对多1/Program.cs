using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace 一对多1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                /*var a = ctx.Articles.Single(a => a.Id == 131113);
                a.IsDeleted = true;
                ctx.SaveChanges();*/
                /*foreach (var a in ctx.Articles.Take(3))
                {
                    Console.WriteLine("**********"+a.Id+","+a.Price);
                }*/

                foreach (var a in ctx.Articles.IgnoreQueryFilters().Take(3))//IgnoreQueryFilters() 忽略全局软删除
                {
                    Console.WriteLine("**********" + a.Id + "," + a.Price);
                }
            }
        }

        static async Task Main4(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                //一般用法，先查询出来，然后修改，进行保存
                /*var a = ctx.Articles.Where(a => a.Id == 6).Single();
                a.Price = 188;
                await ctx.SaveChangesAsync();*/

                //另外一种写法
                /* Article b1 = new Article { Id = 10 };//跟踪通过Id定位
                 b1.Title = "yz";
                 var entry1 = ctx.Entry(b1);
                 entry1.Property("Title").IsModified = true;
                 Console.WriteLine(entry1.DebugView.LongView);
                 ctx.SaveChanges();*/
                //一般用法，先查询出来，然后删除，进行保存
                /*var a = ctx.Articles.Where(a => a.Id == 6).Single();
                ctx.Remove(a);
                await ctx.SaveChangesAsync();*/

                //另外一种写法
                /* Article b1 = new Article { Id = 10 };//跟踪通过Id定位
                 ctx.Entry(b1).State = EntityState.Deleted;
                 ctx.SaveChanges();*/

                //杨中科老师的批量删除
                //await ctx.DeleteRangeAsync<Article>(b => b.Id > 131080 || b.Content == "zack yang");

                //批量更新
                /*await ctx.BatchUpdate<Article>()
                .Set(b => b.Price, b => b.Price + 3)
                .Set(b => b.Title, b => b.Title+DateTime.Now.Second)
                .Where(b => b.Id> 131070)
                .ExecuteAsync();*/

                //批量插入
                /*List<Article> Articles = new List<Article>();
                for (int i = 0; i < 100; i++)
                {
                    Articles.Add(
                        new Article
                        {
                            Title = "abc" + i,
                            Price = new Random().NextDouble(),
                            Content = Guid.NewGuid().ToString(),
                        }
                    );
                }
                using (MyDbContext ctx = new MyDbContext())
                {
                    ctx.BulkInsert(Articles);
                }*/
            }
        }

        static async Task Main3(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                /*//只要一个实体对象和DbContext发生任何的关系(增删查改或者和与DbContext有关系的其他对象产生关联...)，都默认会被DbContext跟踪
                var items = ctx.Articles.Take(3).ToArray();
                var a1 = items[0];
                var a2 = items[1];
                var a3 = items[2];//未改变

                var a4 = new Article { Title = "Zane", Content = "Test1" };
                var a5 = new Article { Title = "ZXXX", Content = "Test2" };//已分离

                a1.Price += 1;//已修改
                ctx.Remove(a2);//已删除
                ctx.Articles.Add(a4);//已添加

                EntityEntry e1 = ctx.Entry(a1);
                EntityEntry e2 = ctx.Entry(a2);
                EntityEntry e3 = ctx.Entry(a3);
                EntityEntry e4 = ctx.Entry(a4);
                EntityEntry e5 = ctx.Entry(a5);

                Console.WriteLine(e1.State);//Modified  已修改
                Console.WriteLine(e2.State);//Deleted   已删除
                Console.WriteLine(e3.State);//Unchanged 未改变
                Console.WriteLine(e4.State);//Added     已添加
                Console.WriteLine(e5.State);//Detached  已分离
                Console.WriteLine(e2.DebugView.LongView);//实体的变化信息*/

                var items = ctx.Articles.AsNoTracking().Take(3).ToArray(); //AsNoTracking 不跟踪状态
                foreach (var item in items)
                {
                    Console.WriteLine(item.Content);
                }
                var a1 = items[0];
                a1.Price += 300; //修改
                Console.WriteLine(ctx.Entry(a1).State);
                await ctx.SaveChangesAsync(); //保存
            }
        }

        static async Task Main2(string[] args)
        {
            /* string name = "Zane";
             int age = 2;

             FormattableString sql = @$"INSERT INTO T_Articles (Title,Content,Price)
                     SELECT Title, {name}, Price FROM T_Articles WHERE Price = {age}";
             Console.WriteLine("Format:" + sql.Format);
             Console.WriteLine("ArgumentCount:"+ sql.ArgumentCount);
             return;*/

            using (MyDbContext ctx = new MyDbContext())
            {
                /*string titlePattern = "%Z%";*/
                /*foreach (var a in ctx.Articles)
                {
                    Console.WriteLine(a.Title);
                }*/
                /*foreach (var a in await ctx.Articles.ToListAsync())//异步方法
                {
                    Console.WriteLine(a.Title);
                }*/

                /*await ctx.Database.ExecuteSqlInterpolatedAsync(@$"INSERT INTO T_Articles (Title,Content,Price)
                    SELECT Title, {name}, Price FROM T_Articles WHERE Price = {age}");*/
                /*var querryable= ctx.Articles.FromSqlInterpolated($"SELECT * FROM T_Articles WHERE Title LIKE {titlePattern} ");//ORDER BY NEWID()
                 foreach (var a in querryable.OrderBy(a=>Guid.NewGuid()).Skip(1).Take(2))
                 {
                     Console.WriteLine(a.Id+","+a.Title);
                 }*/

                //ADO.NET 原生方法
                /*DbConnection conn = ctx.Database.GetDbConnection(); //拿到Context对应的底层Connection
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Price,COUNT(*) FROM T_Articles GROUP BY Price";
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            double price = reader.GetDouble(0);
                            int count = reader.GetInt32(1);
                            Console.WriteLine($"{price}:{count}");
                        }
                    }
                }*/

                //Dapper

                var items = ctx
                    .Database.GetDbConnection()
                    .Query<GroupArticleByPrice>(
                        "SELECT Price,COUNT(*) PCount FROM T_Articles GROUP BY Price"
                    );
                foreach (var item in items)
                {
                    Console.WriteLine(item.Price + ":" + item.PCount);
                }
            }
        }

        static void Main1(string[] args)
        {
            /*//关联添加数据
            Article a1 = new Article();
            a1.Title = "关于.NET 5正式发布";
            a1.Content = ".NET是升级版";
            Comment c1 = new Comment { Message = "已经再用了", Article = a1 };
            Comment c2 = new Comment { Message = "不错不错", Article = a1 };
            using (MyDbContext ctx = new MyDbContext())
            {
                ctx.Comments.Add(c1);
                ctx.Comments.Add(c2);
                await ctx.SaveChangesAsync();
            }*/

            using (MyDbContext ctx = new MyDbContext())
            {
                /*Article a1 = new Article();
                a1.Title = "Zane要努力要上进";
                a1.Content = "据可靠消息说.....";
                Comment c1 = new Comment { Message = "太菜了把", Article = a1 };
                Comment c2 = new Comment { Message = "甄读假读", Article = a1 };
                a1.Comments.Add(c1);
                a1.Comments.Add(c2);

                ctx.Articles.Add(a1);
                ctx.Comments.Add(c1);
                ctx.Comments.Add(c2);
                ctx.SaveChanges();

                Article a1 = new Article();
                a1.Title = "Zane要努力要上进";
                a1.Content = "据可靠消息说.....";
                Comment c1 = new Comment { Message = "太菜了把" };
                Comment c2 = new Comment { Message = "甄读假读" };
                a1.Comments.Add(c1);
                a1.Comments.Add(c2);
                ctx.Articles.Add(a1);
                ctx.SaveChanges();

                Article a = ctx.Articles.Include(a => a.Comments).Single(a => a.Id == 1);// LEFT JOIN
                Console.WriteLine(a.Title);
                foreach (Comment comment in a.Comments)
                {
                    Console.WriteLine(comment.Id + ":" + comment.Message);
                }
                Comment cmt = ctx.Comments.Include(c => c.Article).Single(c => c.Id == 1);// INNER JOIN
                Console.WriteLine(cmt.Message);
                Console.WriteLine(cmt.Article.Id + "," + cmt.Article.Title);*/

                //关系的外键属性的设置
                /*var a1 = ctx.Articles.Select(a => new { a.Id, a.Title }).First();
                Console.WriteLine(a1.Id+","+a1.Title);*/
                /*var cmt = ctx.Comments.Select(c=> new { Id=c.Id,Aid=c.Article.Id}).Single(c => c.Id == 1);//只获取我们需要的列数据
                Console.WriteLine(cmt.Id + "," + cmt.Aid);*/
                /*var cmt = ctx.Comments.Single(c => c.Id == 1);//只获取我们需要的列数据
                Console.WriteLine(cmt.Id + "," + cmt.ArticleId);*/

                /*User u1 = new User { Name = "鑫Cool" };
                Leave l1 = new Leave { Remarks = "回家处理事情", Requester = u1 };
                ctx.Leaves.Add(l1);
                ctx.SaveChanges();*/
                //测试一对多
                /*var a = ctx.Articles.Include(a => a.Comments).First();
                Console.WriteLine(a.Title);
                foreach (var cmd in a.Comments)
                {
                    Console.WriteLine(cmd.Message);
                }*/
                //IQueryable "服务器端评估"
                //IQueryable<Comment> cmts = ctx.Comments.Where(c => c.Message.Contains("了"));
                //IEnumerable "客户端评估"
                /*IEnumerable<Comment> cmts = ctx.Comments;
                foreach (var c in cmts.Where(c => c.Message.Contains("了")))
                {
                    Console.WriteLine(c.Message);
                }*/
                //在某些场景下"客户端评估"也是可以的
                //var cmts = ctx.Comments.Select(c => new { Id=c.Id,Pre=c.Message.Substring(0,2)+"..."});
                /*var cmts = ((IEnumerable<Comment>)ctx.Comments).Select(c => new { Id = c.Id, Pre = c.Message.Substring(0, 2) + "..." });
                foreach (var c in cmts)
                {
                    Console.WriteLine(c.Id+c.Pre);
                }*/

                /*Console.WriteLine("准备Where");
                IQueryable<Article> arts = ctx.Articles.Where(a=>a.Title.Contains("微软"));//构建了一个可以被执行的查询
                Console.WriteLine("准备Foreach");
                foreach (var a in arts)
                {
                    Console.WriteLine(a.Title);
                }
                Console.WriteLine("结束Foreach");*/
                /*IQueryable<Article> arts = ctx.Articles.Where(a => a.Id > 1);
                IQueryable<Article> arts2 = arts.Skip(2);
                IQueryable<Article> arts3 = arts2.Take(3);
                IQueryable<Article> arts4 = arts3.Where(a=>a.Title.Contains("了"));
                arts4.ToArray();*/
                /*IQueryable<Article> arts = ctx.Articles.Where(a => a.Id > 1 && a.Title.Contains("了")).Skip(2).Take(3);
                arts.ToArray();*/
                //QueryArticles("了", true, false, 80);
                foreach (var a in ctx.Articles) //.ToList()  加载到内存
                {
                    Console.WriteLine(a.Title);
                    Thread.Sleep(10);
                }
            }
        }

        static void QueryArticles(
            string searchWords,
            bool searchAll,
            bool orderByPrice,
            double upperPrice
        )
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                IQueryable<Article> arts = ctx.Articles.Where(a => a.Price <= upperPrice);
                if (searchAll)
                {
                    arts = arts.Where(a =>
                        a.Title.Contains(searchWords) || a.Content.Contains(searchWords)
                    );
                }
                else
                {
                    arts = arts.Where(a => a.Title.Contains(searchWords));
                }
                if (orderByPrice)
                {
                    arts = arts.OrderBy(a => a.Price);
                }
                foreach (var a in arts)
                {
                    Console.WriteLine(a.Title);
                }
            }
        }
    }
}
