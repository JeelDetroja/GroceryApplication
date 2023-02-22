using GroceryAPI.Entities;
using GroceryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        #region privet filds
        private readonly ICartRepository _cartRepository;
        #endregion privet filds

        #region constructor
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        #endregion constructor

        #region add item
        [HttpPost(Name = "AddItem")]
        public ActionResult AddItem(AddCartItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cartRepository.AddCartItem(model);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception e)
            {
                string m = e.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }
        }
        #endregion add item

        #region get products by UserId
        //[Route("[action]")]
        //[Authorize(Roles = "Admin, Customer")]
        [HttpGet("{userId}", Name = "GetCartItems")]
        public async Task<ActionResult> GetCartItems(int userId)
        {
            try
            {
                var products = await _cartRepository.GetProducts(userId);
                if (products != null)
                {
                    //var result = products.Select(x => new ProductDto(x)).ToList();

                    // var returnProducts = _mapper.Map<IList<ProductDto>>(products.ToList());

                    return Ok(products);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                string m = ex.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }
        }
        #endregion get products by UserId

        #region Delete Item
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteItem")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var productFromRepo = await _cartRepository.GetProduct(id);

                if (productFromRepo == null)
                {
                    return NotFound();
                }

                _cartRepository.DeleteProduct(productFromRepo);
                _cartRepository.Save();

                return Ok();
            }
            catch (Exception e)
            {
                string m = e.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }

        }
        #endregion Delete Product
    }
}
