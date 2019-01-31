using BasketCase.Models;

namespace BasketCase.Discounts
{
    public interface IDiscountVisitor
    {
        void Visit(Basket basket);
    }
}