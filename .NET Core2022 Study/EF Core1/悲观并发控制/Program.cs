using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace 悲观并发控制
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("请输入您的姓名");
            string name = Console.ReadLine();
            using MyDbContext ctx = new MyDbContext();
            using (var tx =  ctx.Database.BeginTransaction()) 
            {
                try
                {
                    Console.WriteLine("准备Select " + DateTime.Now.TimeOfDay);
                    //SQL Server
                    var h1 = ctx.Houses.FromSqlInterpolated($"SELECT * FROM T_Houses WITH (ROWLOCK) WHERE Id = 1").Single();
                    Console.WriteLine("完成Select " + DateTime.Now.TimeOfDay);
                    if (!string.IsNullOrEmpty(h1.Owner))
                    {
                        if (h1.Owner == name)
                        {
                            Console.WriteLine("这个房子已经是你的了，不用抢");
                        }
                        else
                        {
                            Console.WriteLine($"这个房子已经被{h1.Owner}抢走了");
                        }
                        Console.ReadKey();
                        return;
                    }
                    h1.Owner = name;

                    
                    Console.WriteLine("恭喜你，抢到了");
                    ctx.SaveChanges();
                    Console.WriteLine(DateTime.Now + "保存完成");
                    tx.Commit();
                    Console.ReadKey();
                    return; // 成功后退出
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 1205)// 1205 是死锁的 SQL 错误代码
                {

                    Console.WriteLine("死锁发生，正在重试...");
                    tx.Rollback(); // 回滚事务
                    await Task.Delay(1000); // 等待一段时间再重试
                }

               
            }

            Console.WriteLine("重试次数已用完，操作失败。");

        }
    }
}
