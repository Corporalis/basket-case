using BasketCase.Discounts;
using BasketCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketCase.Api.Controllers
{
    [Route("discounts")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountContainer _discountContainer;

        public DiscountController(IDiscountContainer discountContainer)
        {
            _discountContainer = discountContainer;
        }

        // _apply is intentional, _ represent actions (when a verb doesn't exist)
        [HttpPost]
        [Route("_apply")]
        public IActionResult Apply(BasketValidation basketValidation)
        {
            // basket validation excludes items that shouldn't be passed up
            var basket = new Basket(basketValidation);
            _discountContainer.Accept(basket);

            return Ok(basket);
        }
    }
}
