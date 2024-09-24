using System.Threading.Tasks;

namespace 一对一
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                /*Order order = new Order();
                order.Address = "测试区涿州市";
                order.Name = "3C充电器";
                Delivery delivery = new Delivery();
                delivery.CompanyName = "快到天际快递";
                delivery.Number = "SN666888";
                delivery.Order = order;
                ctx.Deliveries.Add(delivery);
                await ctx.SaveChangesAsync();//插入*/
                /*//查询
                Order o1 = await ctx.Orders.Include(o => o.Delivery).FirstAsync(o => o.Name.Contains("充电器"));
                Console.WriteLine($"名称:{o1.Name},单号:{o1.Delivery.Number}");*/
                /*var orders= ctx.Orders.Where(o => o.Delivery.CompanyName == "快到天际快递");
                 foreach (var o in orders)
                 {
                     Console.WriteLine(o.Name);
                 }*/


            }
        }
    }
}
