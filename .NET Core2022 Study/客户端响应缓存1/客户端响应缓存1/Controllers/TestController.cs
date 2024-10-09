using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using Zack.ASPNETCore;

namespace 客户端响应缓存1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IMemoryCacheHelper memoryCacheHelper;
        private readonly IDistributedCache distCache;
        private readonly IDistributedCacheHelper distCacheHelper;

        public TestController(IMemoryCache memoryCache, IMemoryCacheHelper memoryCacheHelper, IDistributedCache distCache, IDistributedCacheHelper distCacheHelper)
        {
            this.memoryCache = memoryCache;
            this.memoryCacheHelper = memoryCacheHelper;
            this.distCache = distCache;
            this.distCacheHelper = distCacheHelper;
        }
        [HttpGet]
        public async Task<ActionResult<Book?>> GetBookById(long id)
        {

            //GetOrCreateAsync二合一：1.从缓存取数据  2.从数据源取数据，并且返回给调用者以及保存到缓存
            Console.WriteLine($"开始执行GetBookById，id={id}" + DateTime.Now);
            Book? b = await memoryCache.GetOrCreateAsync("Book" + id, async (e) =>
            {
                Console.WriteLine($"缓存中没有找到，到数据库中查一查，id={id}");
                //e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);//缓存有效期10秒---绝对过期时间
                //e.SlidingExpiration = TimeSpan.FromSeconds(10);//滑动过期时间
                //混合使用
                // e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                //e.SlidingExpiration = TimeSpan.FromSeconds(10);
                //new Random().Next();//.NET 6之前都是这样，很麻烦~
                e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Random.Shared.Next(10, 15));//过期时间随机
                return await MyDbContext.GetByIdAsync(id);
            });
            Console.WriteLine($"GetOrCreateAsync结果{b}");
            if (b == null)
            {

                return NotFound($"找不到id={id}的书");
            }
            else
            {
                return b;
            }
        }

        /*        [HttpGet]
                [ResponseCache(Duration = 10)]//客户端缓存控制
                public DateTime Now()
                {
                    return DateTime.Now;//返回当前时间
                }*/

        [HttpGet]
        public String Now()//测试Redis
        {
            string? s = distCache.GetString("Now");
            if (s == null)
            {
                s = DateTime.Now.ToString();
                var opt = new DistributedCacheEntryOptions();
                opt.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                distCache.SetString("Now", s, opt);
            }
            return s;
        }

        [HttpGet]
        public async Task<ActionResult<Book?>> Test2(long id)
        {
            var b = await memoryCacheHelper.GetOrCreateAsync("Book" + id, async (e) => { return await MyDbContext.GetByIdAsync(id); },10);
            if (b==null)
            {
                return NotFound("不存在");
            }
            else
            {
                return b;

            }
        }

        [HttpGet]
        public async Task<ActionResult<Book?>> Test3(long id)
        {
            Book? book;
            string? s = await distCache.GetStringAsync("Book" + id);
            if (s==null)
            {
                Console.WriteLine($"从数据库中取 id={id}");
                book = await MyDbContext.GetByIdAsync(id);
                await distCache.SetStringAsync("Book" + id, JsonSerializer.Serialize(book));
            }
            else
            {
                Console.WriteLine($"从缓存中取 id={id}");
                book = JsonSerializer.Deserialize<Book?>(s);
            }
            if (book == null)
            {
                return NotFound("不存在");
            }
            else
            {
                return book;

            }
        }

        [HttpGet]
        public async Task<ActionResult<Book?>> Test6(long id)
        {
            var book = await distCacheHelper.GetOrCreateAsync("Book" + id, async
                (e) => {
                    e.SlidingExpiration = TimeSpan.FromSeconds(5);
                   var book = await MyDbContext.GetByIdAsync(id);
                    return book;
                }, 20);
            if (book == null)
            {
                return NotFound("不存在");
            }
            else
            {
                return book;

            }
        }

    }
}
