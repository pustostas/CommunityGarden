namespace CommunityGarden.Models
{
    public class Herb
    {
        public int HerbId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string CatalogueUrl { get; set; }

        public string WaterEvery { get; set; }
        
        public int FertilizeEvery { get; set; }

        public string FertilizerType { get; set; }
    }
}
