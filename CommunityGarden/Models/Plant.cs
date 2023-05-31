namespace CommunityGarden.Models
{
    public class Plant
    {
        public int PlantId { get; set; }

        public int PlotId { get; set; }

        public int HerbId { get; set; }

        public string PlantDate { get; set; }

        public string LastWatered { get; set; }

        public string LastFertilized { get; set; }
    }
}
