namespace CommunityGarden.Models
{
    public class GardenUser
    {
        public int GardenUserId { get; set; }

        public int UserId { get; set; }

        public int GardenId { get; set; }

        public int Role { get; set; } // 0 - user, 1 - owner. 
    }
}
