using System.Collections.Generic;
using System.Threading.Tasks;
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
        [HttpPost]
        [Route("_apply")]
        public IActionResult Apply(Basket basket)
        {
            _discountContainer.Accept(basket);

            return Ok(basket);
        }
    }
}
