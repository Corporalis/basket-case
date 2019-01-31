using BasketCase.Models;

namespace BasketCase.Discounts
{
    public interface IDiscountContainer
    {
        void Accept(Basket basket);
    }
}