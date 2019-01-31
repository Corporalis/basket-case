namespace BasketCase.Models
{
    public class Product
    {
        // realistically a product would likely have multiple categories
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
