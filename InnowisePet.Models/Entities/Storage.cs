namespace InnowisePet.Models.Entities
{
    public class Storage
    {
        public string title { get; set; }
        public Guid id { get; set; }
        public Guid location_id { get; set; }
        public string LocationName { get; set; }
    }
}
