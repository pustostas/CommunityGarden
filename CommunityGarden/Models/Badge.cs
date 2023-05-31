namespace CommunityGarden.Models
{
    public class Badge
    {
        public int BadgeID { get; set; }
        
        public int UserId { get; set; }

        public int AchievmentId { get; set; }

        public int Progress { get; set; }
    }
}
