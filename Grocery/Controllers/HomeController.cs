using Grocery.Models;
using Grocery.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        #region privet variables
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        HttpClient client = new HttpClient();
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion privet variables

        #region constructor
        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this.client = _httpClientFactory.CreateClient("grocery");
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion constructor

        #region All Products
        [Route("[action]/")]
        public IActionResult Index()
        {
            try
            {
                List<ProductViewModel> modelList = new List<ProductViewModel>();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/product").Result;
                if (responce.IsSuccessStatusCode)
                {
                    string data = responce.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                }
                return View(modelList);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion All Products

        #region Orders
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]")]
        public IActionResult Orders()
        {
            try
            {
                List<OrderViewModel> modelList = new List<OrderViewModel>();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/order").Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<OrderViewModel>>(data);
                }
                else if (response.StatusCode.ToString() == "NotFound")
                {
                    ModelState.AddModelError("", "product not found");
                }
                return View(modelList);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion Orders

        #region Product details
        [HttpGet("{id}")]
        [Route("[action]/{id?}")]
        public IActionResult ProductDetails(int id)
        {
            try
            {
                if (id != 0)
                {
                    ProductViewModel model = new ProductViewModel();
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/product/" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<ProductViewModel>(data);
                    }
                    else if (response.StatusCode.ToString() == "NotFound")
                    {
                        ModelState.AddModelError("", "Product not found");
                    }
                    return View(model);
                }
                return RedirectToAction("allProducts");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion Product details

        #region delete product
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Employee")]
        [Route("[action]/{id}")]
        public IActionResult ProductDelete(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/product/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode.ToString() == "NotFound")
                {
                    ModelState.AddModelError("", "product not found");
                }
                else
                {
                    ModelState.AddModelError("", "product not deleted");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion delete product

        #region create product
        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> CreateProduct(ProductCreationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    string folder = "img/product/";
                    model.ProductPhotoPath = await UploadImage(folder, model.Photo);
                    if (model.ProductPhotoPath != null)
                    {
                        #region Add with api
                        model.UpdatedBy = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
                        model.CreatedBy = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
                        model.isActivated = true;
                        var putTask = client.PostAsJsonAsync<ProductCreationModel>(client.BaseAddress + "/product", model);
                        putTask.Wait();

                        var result = putTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("index", "home");
                        }
                        else
                        {
                            ModelState.AddModelError("", result.StatusCode.ToString());
                        }
                        #endregion Add with api
                    }
                }
                return View(model);
            }
            return View();
        }
        #endregion create product

        #region UploadImage Method
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        #endregion UploadImage Method

        #region update product
        [HttpGet]
        [Route("[action]/{id?}")]
        public IActionResult UpdateProduct(int id)
        {
            try
            {
                if (id != 0)
                {
                    ProductViewModel model = new ProductViewModel();
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/product/" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<ProductViewModel>(data);
                    }
                    else if (response.StatusCode.ToString() == "NotFound")
                    {
                        ModelState.AddModelError("", "Product not found");
                    }
                    ProductUpdateViewModel updateModel = new ProductUpdateViewModel
                    {
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        ProductCategoryName = model.ProductCategoryName,
                        ProductPrice = model.ProductPrice,
                        Discount = model.Discount,
                        ProductPhotoPath = model.ProductPhotoPath,
                        Description = model.Description,
                        CreatedBy = model.CreatedBy,
                        UpdatedBy = model.UpdatedBy,
                        isActivated = model.isActivated
                    };
                    return View(updateModel);
                }
                return RedirectToAction("index");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        [HttpPost]
        [Route("[action]/{id?}")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Photo != null)
                    {
                        string folder = "img/product/";
                        model.ProductPhotoPath = await UploadImage(folder, model.Photo);
                    }
                    ProductCreationModel updateModel = new ProductCreationModel
                    {
                        ProductCategoryId = model.ProductCategoryId,
                        ProductName = model.ProductName,
                        ProductPrice = model.ProductPrice,
                        Discount = model.Discount,
                        ProductPhotoPath = model.ProductPhotoPath,
                        Description = model.Description,
                        CreatedBy = model.CreatedBy,
                        UpdatedBy = Convert.ToInt32(Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault())),
                        isActivated = true
                    };

                    var stringContent = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");
                    var putTask = client.PutAsync(client.BaseAddress + "/product/" + model.ProductId, stringContent);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.StatusCode.ToString());
                    }
                }
                return View(model);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion update product

        #region update order
        [HttpGet]
        [Route("[action]/{model?}")]
        public IActionResult DeliveredOrder(int model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrderViewModel updateModel = new OrderViewModel
                    {
                        OrderId = model,
                        DeliveredDate = DateTime.Now,
                        isDelivered = true
                    };

                    var stringContent = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");
                    var putTask = client.PutAsync(client.BaseAddress + "/order/" + updateModel.OrderId, stringContent);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("orders", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.StatusCode.ToString());
                    }
                }
                return View(model);
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        #endregion update order

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
