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
    public class UserController : ControllerBase
    {
        #region privet field
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;
        #endregion privet field

        #region constructor
        public UserController(AppDbContext context, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _context = context;
        }
        #endregion constructor

        #region SignUp
        [HttpPost(Name = "SignUp")]
        public ActionResult SignUp(UserForCreationDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model == null)
                    {
                        return BadRequest();
                    }
                    int count = _accountRepository.GetUserByEmail(model.UserEmail);
                    if (count == 0)
                    {
                        _accountRepository.AddUser(model);
                        return Ok();
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User already exist ! please login with diffrent name");
                        return BadRequest(ModelState);
                    }
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
        #endregion SignUp

        #region get user by id
        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult> GetUser(int userId)
        {
            try
            {
                var user = await _accountRepository.GetUser(userId);
                if (user != null)
                {
                    var result = new UserDto(user);
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                string m = ex.Message.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error While retriving data from database");
            }
        }
        #endregion get product by id
    }
}
