using AutoMapper;
using GroceryAPI.Entities;
using GroceryAPI.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductController : ControllerBase
    {
        #region privet filds
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        #endregion privet filds

        #region constructor
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        #endregion constructor

        #region get products
        //[Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                if(products != null)
                {
                    var result = products.Select(x => new ProductDto(x)).ToList();

                   // var returnProducts = _mapper.Map<IList<ProductDto>>(products.ToList());

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

        #region get product by id
        //[Route("[action]")]
        //[Authorize(Roles = "Admin, Customer")]
        [HttpGet("{productId}", Name = "GetProduct")]
        public async Task<ActionResult> GetProduct(int productId)
        {
            try
            {
                var product = await _productRepository.GetProduct(productId);
                if (product != null)
                {
                    var result = new ProductDto(product);

                    //var returnProducts = _mapper.Map<ProductDto>(product);

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
        #endregion get product by id

        #region create product (post)
        //[Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreateProduct")]
        public ActionResult<ProductDto> CreateProduct(ProductForCreationDto product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (product == null)
                    {
                        return BadRequest();
                    }
                    int count = _productRepository.GetProductByName(product.ProductName);
                    if (count > 0)
                    {
                        ModelState.AddModelError("ProductName", "Product name already in use");
                        return BadRequest(ModelState);
                    }
                    var productEntity = _mapper.Map<Models.Product>(product);
                    _productRepository.AddProduct(productEntity);
                    _productRepository.Save();
                    return Created("api/product", productEntity.ProductName);
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
        #endregion create product (post)

        #region update product (put)
        //[Authorize(Roles = "Admin")]
        [HttpPut("{productId}", Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int productId, ProductForUpdateDto product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productFromRepo = await _productRepository.GetProduct(productId);
                    if (productFromRepo != null)
                    {
                        //if (_productRepository.GetProductByName(product.ProductName) != 0)
                        //{
                        //    ModelState.AddModelError("ProductName", "Product name already in use");
                        //    return BadRequest(ModelState);
                        //}

                        var productToAdd = _mapper.Map<Models.Product>(product);
                        productToAdd.ProductId = productId;

                        _mapper.Map(product, productFromRepo);
                        _productRepository.UpdateProduct(productFromRepo);
                        _productRepository.Save();

                        //var productToReturn = _mapper.Map<ProductDto>(productToAdd);

                        //return CreatedAtRoute(new { productName = productToReturn.ProductName },
                        //    productToReturn);
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                string ex = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }
        }
        #endregion update product (put)

        #region Delete Product
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{productId}", Name = "DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            try
            {
                var productFromRepo = await _productRepository.GetProduct(productId);

                if (productFromRepo == null)
                {
                    return NotFound();
                }

                _productRepository.DeleteProduct(productFromRepo);
                _productRepository.Save();

                return Ok(new ProductDto(productFromRepo));
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