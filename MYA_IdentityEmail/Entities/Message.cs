namespace MYA_IdentityEmail.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
        public bool IsFavorite { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
