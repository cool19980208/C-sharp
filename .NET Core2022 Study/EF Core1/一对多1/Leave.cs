namespace 一对多1
{
    class Leave//单据表，多端对一端
    {
        public long Id { get; set; }
        public User Requester { get; set; }//对的User的这个表
        public User Approver { get; set; }
        public string Remarks { get; set; }
    }
}
