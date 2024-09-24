using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace 一对多1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string name = "Zane";
            int age = 2;

            FormattableString sql = @$"INSERT INTO T_Articles (Title,Content,Price)
                    SELECT Title, {name}, Price FROM T_Articles WHERE Price = {age}";
            Console.WriteLine("Format:" + sql.Format);
            Console.WriteLine("ArgumentCount:"+ sql.ArgumentCount);
            return;
            using (MyDbContext ctx = new MyDbContext())
            {
                /*foreach (var a in ctx.Articles)
                {
                    Console.WriteLine(a.Title);
                }*/
                /*foreach (var a in await ctx.Articles.ToListAsync())//异步方法
                {
                    Console.WriteLine(a.Title);
                }*/

                await ctx.Database.ExecuteSqlInterpolatedAsync(@$"INSERT INTO T_Articles (Title,Content,Price)
                    SELECT Title, {name}, Price FROM T_Articles WHERE Price = {age}");

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
                foreach (var a in ctx.Articles)//.ToList()  加载到内存
                {
                    Console.WriteLine(a.Title);
                    Thread.Sleep(10);
                }
            }
        }
        static void QueryArticles(string searchWords, bool searchAll, bool orderByPrice, double upperPrice)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                IQueryable<Article> arts = ctx.Articles.Where(a => a.Price <= upperPrice);
                if (searchAll)
                {
                    arts = arts.Where(a => a.Title.Contains(searchWords) || a.Content.Contains(searchWords));
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
