namespace 一对多1
{
    class Comment//评论实体类
    {
        public long Id { get; set; }//主键
        public string Message { get; set; }//评论内容
        public Article Article { get; set; }//外键，连接文章父亲的实体类  评论属于哪篇文章
        public long ArticleId { get; set; }//额外外键属性
    }
}
