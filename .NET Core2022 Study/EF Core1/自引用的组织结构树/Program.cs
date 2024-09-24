using System;
using System.Linq;
using System.Threading.Tasks;

namespace 自引用的组织结构树
{
    internal class Program//特殊的一对多案例
    {
        static async Task Main(string[] args)
        {
            /*//既可以设置一个ou的Parent，也可以把一个节点加入到父节点的Children.Add(...)
            OrgUnit ouRoot = new OrgUnit { Name = "文静集团全球总部" };

            OrgUnit ouAsia = new OrgUnit { Name = "文静集团亚太区总部" };
            ouAsia.Parent = ouRoot;

            OrgUnit ouAmerica = new OrgUnit { Name = "文静集团美洲区总部" };
            ouAmerica.Parent = ouRoot;

            OrgUnit ouUSA = new OrgUnit { Name = "文静美国" };
            ouUSA.Parent = ouAmerica;

            OrgUnit ouCan = new OrgUnit { Name = "文静加拿大" };
            ouCan.Parent = ouAmerica;

            OrgUnit ouChina = new OrgUnit { Name = "文静集团(中国)" };
            ouChina.Parent = ouAsia;

            OrgUnit ouSg = new OrgUnit { Name = "文静集团(新加坡)" };
            ouSg.Parent = ouAsia;

            using (MyDbContext ctx = new MyDbContext())
            {
                ctx.OrgUnits.Add(ouRoot);
                ctx.OrgUnits.Add(ouAsia);
                ctx.OrgUnits.Add(ouAmerica);
                ctx.OrgUnits.Add(ouUSA);
                ctx.OrgUnits.Add(ouCan);
                ctx.OrgUnits.Add(ouChina);
                ctx.OrgUnits.Add(ouSg);
                await ctx.SaveChangesAsync();
            }*/
            using (MyDbContext ctx = new MyDbContext())
            {
                OrgUnit ouRoot = ctx.OrgUnits.Single(o => o.Parent == null);//寻找根节点
                Console.WriteLine(ouRoot.Name);
                PrintChildren(1, ctx, ouRoot);
            }
        }
        /// <summary>
        /// 缩进打印parent的所有的子节点
        /// </summary>
        /// <param name="identLevel"></param>
        /// <param name="ctx"></param>
        /// <param name="parent"></param>
        static void PrintChildren(int identLevel,MyDbContext ctx,OrgUnit parent)
        {
            var children = ctx.OrgUnits.Where(o => o.Parent == parent);
            foreach (var child in children)
            {
                Console.WriteLine(new String('\t',identLevel)+child.Name);
                PrintChildren(identLevel + 1, ctx, child);//打印以我为父节点的子节点
            }
        }
    }
}
