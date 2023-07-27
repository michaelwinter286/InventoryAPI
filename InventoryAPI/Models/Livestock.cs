namespace InventoryAPI.Models
{
    public class Livestock
    {
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public string Breed { get; set; }
        public string? Description { get; set; }
    }
}
