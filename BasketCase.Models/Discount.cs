namespace BasketCase.Models
{
    public class Discount
    {
        public Discount(decimal value)
        {
            Value = value;
        }
        public decimal Value { get; }
    }
}