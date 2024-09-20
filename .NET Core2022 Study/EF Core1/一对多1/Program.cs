namespace 一对多1
{
    class Program
    {
        static void Main(string[] args)
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

                User u1 = new User { Name = "鑫Cool" };
                Leave l1 = new Leave { Remarks = "回家处理事情", Requester = u1 };
                ctx.Leaves.Add(l1);
                ctx.SaveChanges();


            }
        }
    }
}
