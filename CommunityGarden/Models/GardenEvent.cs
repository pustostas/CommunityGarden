namespace CommunityGarden.Models
{
    public class GardenEvent
    {
        public int GardenEventId { get; set; }

        public int GardenUserId { get; set; }

        public string Date { get; set; }
        public string Description { get; set; }
    }
}
