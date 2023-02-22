using GroceryAPI.Entities;
using GroceryAPI.Models;
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
    public class OrderController : ControllerBase
    {
        #region privet filds
        private readonly ICartRepository _cartRepository;
        #endregion privet filds

        #region constructor
        public OrderController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        #endregion constructor

        #region add item
        [HttpPost(Name = "AddOrder")]
        public async Task<ActionResult> AddOrder(Order model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cartRepository.AddOrder(model);

                    List<CartItem> cartItems = await _cartRepository.GetProducts(model.CustomerId);

                    if (cartItems != null)
                    {
                        foreach (var item in cartItems)
                        {
                            item.isActivated = false;
                        }
                        _cartRepository.Save();

                        return Ok();
                    }
                    return NotFound();
                    



                    //if(cartItems == null)
                    //{
                    //    return NotFound();
                        
                    //}
                    //_cartRepository.DeleteProduct(cartItems);

                    ////_cartRepository.Save();

                    //return Ok();
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

        #region get products
        [HttpGet(Name = "GetOrders")]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                var orders = await _cartRepository.GetOrders();
                if (orders != null)
                {
                    var result = orders.Select(x => new GetOrder(x)).ToList();
                    return Ok(result);
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
        #endregion get product

        #region update item
        [HttpPut("{orderId}", Name = "UpdateOrder")]
        public async Task<ActionResult> UpdateOrder(int orderId, Order model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //_cartRepository.AddOrder(model);

                    var order = await _cartRepository.GetOrder(model.OrderId);

                    //List<CartItem> cartItems = await _cartRepository.GetProducts(model.CustomerId);

                    if (order != null)
                    {
                        order.isDelivered = model.isDelivered;
                        order.DeliveredDate = model.DeliveredDate;

                        _cartRepository.Save();

                        return Ok();
                    }
                    return NotFound();
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
        #endregion update item
    }
}
