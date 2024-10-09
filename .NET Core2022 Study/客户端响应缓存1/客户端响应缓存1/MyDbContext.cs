namespace 客户端响应缓存1
{
    public class MyDbContext
    {
        public static Task<Book?> GetByIdAsync(long id)
        {
            var result = GetById(id);
            return Task.FromResult(result);
        }
        public static Book? GetById(long id)//模拟数据库
        {
            switch (id)
            {
                case 0:
                    return new Book(0, "测试之路");
                case 1:
                    return new Book(1, "保安之路");
                case 2:
                    return new Book(2, "C#之路");
                default:
                    return null;
            }
        }
    }
}
