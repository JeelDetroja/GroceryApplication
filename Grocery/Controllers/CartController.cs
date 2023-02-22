using Grocery.Models;
using Grocery.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Grocery.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class CartController : Controller
    {
        #region variables
        private readonly ILogger<CartController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        HttpClient client = new HttpClient();
        #endregion variables

        #region constructor
        public CartController(IHttpClientFactory httpClientFactory, ILogger<CartController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this.client = _httpClientFactory.CreateClient("grocery");
        }
        #endregion constructor

        #region add item to cart
        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Customer")]
        public IActionResult AddItem(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddCartItem item = new AddCartItem
                {
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    Subtotal = (model.Quantity * model.Price),
                    CreatedBy = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()),
                    UpdatedBy = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()),
                    isActivated = true
                };

                var puttask = client.PostAsJsonAsync<AddCartItem>(client.BaseAddress + "/cart", item);
                puttask.Wait();
                var result = puttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index", "home");
                }
                else if (result.StatusCode.ToString() == "BadRequest")
                {
                    ModelState.AddModelError("", "item not added sucsessfully");
                }
                else
                {
                    ModelState.AddModelError("", result.StatusCode.ToString());
                }
                return View(model);
            }
            return View();
        }
        #endregion add item to cart

        #region View Cart
        [Route("[action]")]
        public IActionResult ViewCart()
        {
            try
            {
                List<CartItem> modelList = new List<CartItem>();
                int userId = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/cart/" + userId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<CartItem>>(data);
                }
                else if (response.StatusCode.ToString() == "NotFound")
                {
                    ModelState.AddModelError("", "Cart is Empty");
                }
                return View(modelList);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion View Cart

        #region delete item from cart
        [HttpDelete("{id}")]
        [Route("[action]/{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/cart/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ViewCart");
                }
                else if (response.StatusCode.ToString() == "NotFound")
                {
                    ModelState.AddModelError("", "product not found");
                }
                else
                {
                    ModelState.AddModelError("", "product not deleted");
                }
                return RedirectToAction("ViewCart");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion delete item from cart

        #region order items
        [HttpPost("{total}")]
        [Route("[action]/{total}")]
        public IActionResult OrderItem(decimal total)
        {
            Order model = new Order()
            {
                CustomerId = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault()),
                GrandTotal = total,
                isDelivered = false,
                OrderDate = DateTime.Now,
                DeliveredDate = DateTime.Now
            };

            if(model.GrandTotal == 0)
            {
                return RedirectToAction("index", "home");
            }
            var puttask = client.PostAsJsonAsync<Order>(client.BaseAddress + "/order", model);
            puttask.Wait();
            var result = puttask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "home");
            }
            else if (result.StatusCode.ToString() == "BadRequest")
            {
                ModelState.AddModelError("", "order not placed sucsessfully");
            }
            else
            {
                ModelState.AddModelError("", result.StatusCode.ToString());
            }
            return View(model);

        }
        #endregion order items
    }
}
