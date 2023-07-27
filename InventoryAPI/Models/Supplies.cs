namespace InventoryAPI.Models
{
    public class Supplies
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }
        public int Minimum { get; set; }
        public string? Description { get; set; }
    }
}
