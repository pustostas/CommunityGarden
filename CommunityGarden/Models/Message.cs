namespace CommunityGarden.Models
{
    public class Message
    {

        public int MessageId { get; set; }

        public int ChatId { get; set; }

        public string SentTime { get; set; }

        public string Text { get; set; }

        public string SenderId { get; set; }
    }
}
