using System.Collections.Generic;

namespace 一对多1
{
    class Article//文章实体类
    {
        public long Id { get; set; }//Id
        public string Title { get; set; }//标题
        public string Content { get; set; }//文章内容
        //建议给一个空的List，比如new List<Comment>() 此文章的多条评论
        public double Price { get; set; }//测试用的价钱
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
