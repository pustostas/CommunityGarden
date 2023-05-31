namespace CommunityGarden.Models
{
    public class Plot
    {
        public int PlotId { get; set; }

        public int GardenId { get; set; }

        public int SuperviserId { get; set; }

        public string Shape { get; set; }
    }
}
