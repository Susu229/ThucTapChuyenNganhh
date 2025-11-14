namespace ThucTapChuyenNganhh.Models
{
    public class ContactMess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsReplied { get; set; } = false;
        public string ReplyMessage { get; set; } = "";


    }

}
